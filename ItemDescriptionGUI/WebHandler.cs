using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace ItemDescriptionGUI
{
    public class WebHandler
    {

        private const int BUFFER_SIZE = 10;

        private List<CSVRow> newRecords;
        private BackgroundWorker shiftWorker;
        private int rowOffset = 0;
        private int currentRow = 0;

        /// <summary>
        /// Queue of the next 10 rows of the input CSV file and (if enabled) the scraper output for that UPC
        /// </summary>
        public List<Tuple<CSVRow, ScraperOutput>> recordBuffer { get; private set; }

        public Tuple<bool, string> errorState { get; private set; }

        public Dictionary<string, string> commonAbbreviations = new Dictionary<string, string>()
        {
            { "spkg", "sparkling"},
            { "spkl", "sparkling" },
            { "chard", "chardonnay" },
            { "char", "chardonnay" },
            { "cha", "chardonnay" },
            { "shm", "shampoo" },
            { "cond", "conditioner"},
            { "moist", "moisturizing"},
            { "drk", "dark"},
            { "shdw", "shadow"},
            { "bln", "blend"},
            { "blk", "black"},
            { "btl", "bottle"},
            { "stwbry", "strawberry"},
            { "cab", "cabernet"},
            { "mer", "merlot" },
            { "btls", "bottles"},
            { "pk", "pack"},
            { "sauv", "sauvignon" },
            { "asst", "assortment" },
            { "assrt", "assortment" },
            { "asrt", "assortment" },
            { "choc", "chocolate" },
            { "orng", "orange" },
            { "blu", "blue" },
            { "jly", "jelly" },
            { "mffn", "muffin" },
            { "stfd", "stuffed" },
            { "olv", "olives" },
            { "hndl", "handle" },
            { "ganch", "ganache" },
            { "zin", "zinfandel" },
            { "p", "pinot" },
            { "wht", "white" },
            { "grig", "grigio" },
            { "mtn", "mountain" },
            { "frshnr", "freshener" },
            { "dbl", "double" },
            { "dble", "double" },
            { "spcd", "spiced" },
            { "ckn", "chicken" },
            { "trky", "turkey" },
            { "pnt", "peanut" },
            { "btr", "butter" },
            { "ic", "ice cream" },
            { "prf", "proof" },
            { "raspbr", "raspberry" },
            { "bx", "box" },
            { "rsv", "reserver" },
            { "teq", "tequila" },
            { "cnty", "country" },
            { "blckbry", "blackberry" },
            { "cuve", "cuvee" },
            { "slvr", "silver" },
            { "swt", "sweet" },
            { "crn", "cranberry" },
            { "bisc", "biscuit" },
            { "svdi", "savoiardi" },
            { "yog", "yogurt" },
            { "grk", "greek" },
            { "blkby", "blackberry" },
            { "jol", "jolanda" },
            { "flor", "floral" },
            { "orig", "original" },
            { "snk", "snack" },
            { "stk", "stack" },
            { "hbd", "happy birthday" },
            { "purp", "puple" },
            { "tom", "tomato" },
            { "cndy", "candy" },
            { "rspbry", "raspberry" },
            { "chs", "cheese" },
            { "trtmnt", "treatment" },
            { "xmas", "christmas" },
            { "frn", "french" },
            { "bdgr", "badger" },
            { "chdr", "cheddar" },
            { "trts", "treats" },
            { "yog ", "yogurt" },
            { "multgr", "multigrain" },
            { "strwbry", "strawberry" },
            { "rsrve", "reserve" },
            { "spkd", "spiked" },
            { "nr", "noir" },
            { "org", "organic" },
            { "brndy", "brandy" },
            { "rsbrry", "raspberry" },
            { "blnd", "blend" },
            { "blck", "black" },
            { "cdl", "candle" },
            { "cndl", "candle" },
            { "liq", "liqour" },
            { "frz", "frozen" },
            { "turk", "turkey" },
            { "bnls", "boneless" },
            { "sknls", "skinless" },
            { "whl", "wheel" },
            { "bqt", "bouquet" },
            { "pql", "plaque" },
            { "cnap", "cocktail napkins" },
            { "veg", "vegetable" },
        };

        /// <summary>
        /// CSV index of the last item in the buffer
        /// </summary>
        public int rowIndex { get; set; } = 0;

        public string OutputPath;
        public string InputPath;
        public int totalRecordsCount = 0;
        public bool isOffline = false;

        /// <summary>
        /// Creates a new instance of the WebHandler class 
        /// </summary>
        public WebHandler()
        {
            newRecords = new List<CSVRow>();
            recordBuffer = new List<Tuple<CSVRow, ScraperOutput>>();

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd--HH-mm");

            errorState = new Tuple<bool, string>(false, "");

            // Generate a unique file name for the output file 
            OutputPath = desktopPath + "\\ItemDescriptionOuput\\" + "Descriptions_" + dateTime + ".csv";

            // Prevents the "The underlying connection was closed: An unexpected error occurred on a send." error that appeared 6/12
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        /// <summary>
        /// Returns the last row that was modified
        /// </summary>
        /// <returns></returns>
        public Tuple<CSVRow, ScraperOutput> GetLastRow()
        {
            return recordBuffer[recordBuffer.Count-1];
        }

        /// <summary>
        /// Returns the current csv index that the user is working on
        /// </summary>
        /// <returns></returns>
        public int GetCurrentRowIndex()
        {
            return currentRow;
        }

        /// <summary>
        /// Adds a new record to the output list and then writes it
        /// </summary>
        /// <param name="r">Instance of the CSVRow class with new data</param>
        public void AddNewRecord(CSVRow r)
        {
            newRecords.Add(r);

            using (var writer = new StreamWriter(OutputPath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(newRecords);
                writer.Close();
            }
        }

        /// <summary>
        /// Sets the starting row offset
        /// </summary>
        public void SetRowOffset(int offset)
        {
            rowOffset = offset;

        }

        /// <summary>
        /// Left shifts the item buffer by 1 and creates a BackgroundWorker to acquire a new entry
        /// </summary>
        public void ShiftBuffer()
        {

            for (int i = 0; i < recordBuffer.Count; i++)
            {

                if (recordBuffer[i] != null)
                {
                    Console.WriteLine("Item : " + i.ToString() + " " + recordBuffer[i].Item1.full_upc.ToString());
                }
                else
                {
                    Console.WriteLine("Item: " + i.ToString() + " is null");
                }

                if (i + 1 >= recordBuffer.Count)
                {
                    Console.WriteLine("We reached the end");
                    recordBuffer.RemoveAt(i);
                    continue;
                }

                recordBuffer[i] = recordBuffer[i + 1];
            }

            shiftWorker = new BackgroundWorker();

            shiftWorker.WorkerReportsProgress = true;
            shiftWorker.WorkerSupportsCancellation = true;

            shiftWorker.DoWork += ShiftWorker_DoWork;
            shiftWorker.RunWorkerCompleted += ShiftWorker_RunWorkerCompleted;

            shiftWorker.RunWorkerAsync();

            currentRow++;
        }

        private void ShiftWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            rowIndex++;
        }

        /// <summary>
        /// Runs on a separate thread to pull info for the newest item in the buffer
        /// </summary>
        private void ShiftWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            LoadRow(rowIndex);
        }



        /// <summary>
        /// Populates the buffer with entries at the given row offset
        /// </summary>
        public void LoadBufferRows()
        {

            currentRow = rowOffset;
            rowIndex = rowOffset;

            for (int i = 0; i < BUFFER_SIZE; i++)
            {
                LoadRow(rowIndex);
                rowIndex++;
            }
        }

        /// <summary>
        /// Creates a CSVRow instance for a given UPC with data collected from the input CSV file and the internet (if enabled)
        /// </summary>
        /// <param name="theRowIndex">Index of the row in the CSV</param>
        private void LoadRow(int theRowIndex)
        {
            int count = 0;

            using (var reader = new StreamReader(InputPath))
            using (var csv = new CsvReader(reader))
            {

                try
                {
                    csv.Configuration.RegisterClassMap<InputMap>();

                    // Get all the data
                    IEnumerable<CSVRow> records = csv.GetRecords<CSVRow>();

                    // Iterate through the data and lookup the UPCs
                    foreach (var rec in records)
                    {
                        // Once we are at the starting point, start scraping
                        if (count == theRowIndex)
                        {

                            Console.WriteLine("Scraping for index: " + theRowIndex.ToString() + ": " + rec.full_upc);

                            ScraperOutput output = new ScraperOutput();
                            output.desc = "";
                            output.upc = rec.full_upc;

                            // Normal scraping behavior if enabled
                            if (!isOffline)
                            {
                                output = ScrapeWeb(rec.full_upc, rec);
                            }

                            Console.WriteLine("ADD " + rec.full_upc.ToString() + " " + recordBuffer.Count);
                            recordBuffer.Add(new Tuple<CSVRow, ScraperOutput>(rec, output));
                        }

                        count++;
                    }

                }
                catch (HeaderValidationException e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                    errorState = new Tuple<bool, string>(true, e.Message);
                }

                totalRecordsCount = count;
            }
        }

        /// <summary>
        /// Formats a raw scraped string into an item description
        /// </summary>
        /// <param name="product">Raw string</param>
        /// <param name="brand">Brand name to be removed from the first param</param>
        /// <returns></returns>
        private string formatProductDescription(string product, CSVRow record)
        {

            int nameOffset = 13; // 13 characters for the EAN barcode
            nameOffset += 3; // 3 characters for "space hyphen space".

            product = product.Substring(nameOffset);
            product = product.Substring(0, product.Length - 1); // Drop the period at the end of the name

            // Remove the brand name from the scraped name
            product = Regex.Replace(product, record.brand, "", RegexOptions.IgnoreCase);

            // Remove the size if its an exact match (usually isn't)
            product = Regex.Replace(product, record.size, "", RegexOptions.IgnoreCase);

            // Remove commas
            product = product.Replace(",", "");

            return product;
        }

        private ScraperOutput HandleWebError(string upc, bool switchOffline = false, string msg = "")
        {
            ScraperOutput output = new ScraperOutput();

            if (switchOffline)
            {
                output.desc = "Internet connection failed, switching to Offline mode";
            }
            else
            {
                output.desc = "Web Error: " + msg;
            }

            output.upc = upc;

            isOffline = switchOffline;

            return output;
        }

        /// <summary>
        /// Scrapes the internet for product data for a given UPC and its matching CSV row
        /// </summary>
        /// <param name="upc">UPC to search for</param>
        /// <param name="record">CSV record from the input file</param>
        /// <returns></returns>
        private ScraperOutput ScrapeWeb(string upc, CSVRow record)
        {
            ScraperOutput output;

            // Go to the website for that UPC
            string urlAddress = "https://www.barcodelookup.com/" + upc;

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // Copy/pasted web stuff
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }
                    // End Copy/pasted web stuff


                    string data = readStream.ReadToEnd();
                    //Console.WriteLine("Reading data (length #" + data.Length.ToString() + " characters)");

                    // The product name is in the page's meta tag
                    string startStr = "<meta name=\"description\" content=\"Barcode Lookup provides info on EAN ";
                    string endStr = "\">";
                    int startIndex = data.IndexOf(startStr);

                    // Check for invalid data
                    int failIndex = data.IndexOf("<meta name=\"description\" content=\"This barcode doesn't exist in our database. Please search for another barcode in the search box");
                    int badCodeIndex = data.IndexOf("\"This barcode number is not valid");

                    // Catch the scenarios where the website fails to provide a clear definition for the website
                    if (failIndex != -1 || badCodeIndex != -1 || startIndex == -1)
                    {
                        //Console.WriteLine("Could not find UPC");

                        output = new ScraperOutput();
                        output.desc = "null";
                        output.upc = upc;
                        return output;
                    }

                    // If all has worked, grab the ending index
                    int endIndex = data.IndexOf(endStr, startIndex);

                    // Ignore the meta tag
                    startIndex += startStr.Length;
                    int grabLength = endIndex - startIndex;

                    // Grab the website's product name which consists of the EAN barcode and the name
                    string eanAndName = data.Substring(startIndex, grabLength);

                    // Apply my logic to format the title string into something user friendly
                    string name = formatProductDescription(eanAndName, record);

                    // Format and return the output
                    output = new ScraperOutput();
                    output.desc = name;
                    output.upc = upc;

                    return output;
                }
                else
                {
                    // If we are connected to the internet but the query fails, we try again next time
                    string err = "Web error code: " + response.StatusCode.ToString();

                    Console.WriteLine(err);

                    return HandleWebError(upc, false, err);
                }
            }
            catch(Exception e )
            {
                // If we are unable to connect to the internet, we go offline
                Console.WriteLine("Error code: " + e.Message);
                return HandleWebError(upc, true);
            }
        }
    }
}
