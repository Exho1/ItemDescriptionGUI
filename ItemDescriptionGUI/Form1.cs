using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace ItemDescriptionGUI
{

    public partial class Form1 : Form
    {

        private const int DESC_SIZE = 70;

        /// <summary>
        /// Instance of the WebHandler class 
        /// </summary>
        private WebHandler webWorker;
        /// <summary>
        /// Instance of a BackgroundWorker that manages the item buffer
        /// </summary>
        private BackgroundWorker bufferWorker;

        private string lastBrand = "";
        private string lastUPC = "";

        public Form1()
        {
            InitializeComponent();

            webWorker = new WebHandler();

            txtOutputFile.Text = webWorker.OutputPath;
        }

        /// <summary>
        /// Loads the next item in the Record Buffer into the user application
        /// </summary>
        private void LoadNextEntry()
        {
            // If the web worker ran into an error, stop the progress
            if (webWorker.errorState.Item1 == true)
            {
                LogText("[ERROR] " + webWorker.errorState.Item2);
                return;
            }

            // Catch the end condition
            if (webWorker.recordBuffer.Count == 0)
            {
                LogText("No more records left to populate!");

                lblcsvIndex.Text = "All finished! Check the output file location.";
                txtBrand.Text = "";
                txtDesc.Text = "";
                txtSignDesc.Text = "";
                txtUPC.Text = "";
                txtNewBrand.Text = "";
                txtNewDescription.Text = "";
                txtNotes.Text = "";

                return;
            }

            // Get the next entry in the buffer
            Tuple<CSVRow, ScraperOutput> entry = webWorker.recordBuffer[0];

            CSVRow row = entry.Item1;
            ScraperOutput output = entry.Item2;

            // Makes sure that we convert all scientific notation back to real numbers
            string upc = decimal.Parse(row.full_upc, System.Globalization.NumberStyles.Any).ToString();

            // Make sure we didn't lose any leading zeros
            while (upc.Length < 14)
            {
                upc = '0' + upc;
            }

            string currentUPC = upc;
            string lastManu, currentManu;

            string lastNoLeading = lastUPC.TrimStart('0');
            string currentNoLeading = currentUPC.TrimStart('0');

            // How many digits to check for uniqueness
            int checkLength = 7;

            // Get the manufacturer codes
            if (lastNoLeading.Length > checkLength && currentNoLeading.Length > checkLength)
            {
                lastManu = lastNoLeading.Substring(0, checkLength);
                currentManu = currentNoLeading.Substring(0, checkLength);
            }
            else
            {
                // These just have to be non-equal, doesn't matter the value
                lastManu = "1";
                currentManu = "-1";
            }

            // If the manufacturer codes are the same OR there are brand names and they are the same, keep the current brand name
            if (lastManu == currentManu || (lastBrand.ToLower() == row.brand2.ToLower() && row.brand2 != ""))
            {
                //row.brand = txtNewBrand.Text;
            }

            lastBrand = row.brand2;
            lastUPC = upc;

            txtBrand.Text = row.brand2;
            txtDesc.Text = row.desc2;
            txtSignDesc.Text = row.sign != " " ? row.sign : row.pos;
            txtUPC.Text = upc;

            // Fill the new textboxes with the best data of the bunch
            txtNewBrand.Text = (row.brand.Length != 0) ? row.brand : row.brand2;
            txtNewDescription.Text = (row.desc.Length != 0) ? row.desc : output.desc;
            txtNotes.Text = row.notes;

            // Run the formatting logic
            txtNewBrand.Text = toTitlecase(txtNewBrand.Text);
            txtNewDescription.Text = DescriptionFormat(txtNewDescription.Text);

            if (txtNewDescription.Text.ToLower() == "null")
            {
                txtNewDescription.Text = "";
            }

            btnNext.Enabled = true;
            btnSkip.Enabled = true;

            if (chkGoogleUPC.Checked)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=" + txtUPC.Text);
            }

            // Update the label letting the user know where they are
            lblcsvIndex.Text = "Item #" + (webWorker.GetCurrentRowIndex()).ToString() + " of " + webWorker.totalRecordsCount.ToString() + " - Row #" + (webWorker.GetCurrentRowIndex() + 2).ToString();
        }

        /// <summary>
        /// Goes back one index, unused
        /// </summary>
        private void GetLastEntry()
        {
            Tuple<CSVRow, ScraperOutput> entry = webWorker.GetLastRow();

            CSVRow row = entry.Item1;
            ScraperOutput output = entry.Item2;

            txtBrand.Text = row.brand2;
            txtDesc.Text = row.desc2;
            txtSignDesc.Text = row.sign;
            txtUPC.Text = row.full_upc;

            txtNewBrand.Text = row.brand;
            txtNewDescription.Text = row.desc;
            txtNotes.Text = "oops";

            // Crucial to make sure we update this
            webWorker.rowIndex--;
        }


        /// <summary>
        /// Queues the new data to be written and left shifts the buffer
        /// </summary>
        private void SaveCurrentEntry()
        {

            string path = Path.GetDirectoryName(txtOutputFile.Text);

            Directory.CreateDirectory(path);

            // If the file is open in Excel, the program will error cryptically so this catches that
            try
            {
                FileStream fs = File.Open(txtOutputFile.Text, FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch (IOException ex)
            {
                LogText("Output File in use by another program. \nFree it and try again");
                Console.WriteLine(ex.Message);
                return;
            }

            // Create a new CSVRow object with our newly formatted information
            CSVRow r = new CSVRow();

            r.desc = (txtNewDescription.Text == "" || txtNewDescription.Text.ToLower() == "null") ? "" : txtNewDescription.Text;
            r.brand = (txtNewBrand.Text == "" || txtNewBrand.Text.ToLower() == "null" || txtNewBrand.Text == txtBrand.Text) ? "" : txtNewBrand.Text;
            r.notes = txtNotes.Text;
            r.full_upc = txtUPC.Text;

            // Trim whitespace
            r.desc = r.desc.Trim();
            r.brand = r.brand.Trim();

            // Prompts the web worker to proceed
            webWorker.AddNewRecord(r);
            webWorker.ShiftBuffer();

            LogText("Wrote entry to output file");
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInputFile_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = "CSV file";
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            txtInputFile.Text = openFileDialog2.FileName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".csv";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.ShowDialog();

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtOutputFile.Text = saveFileDialog1.FileName;
        }

        /// <summary>
        /// Begins the process
        /// </summary>
        private void btnBegin_Click(object sender, EventArgs e)
        {
            
            if (!File.Exists(txtInputFile.Text))
            {
                LogText("Input file does not exist");
                return;
            }

            // If the file is open in Excel, the program will error cryptically so this catches that
            try
            {
                FileStream fs = File.Open(txtInputFile.Text, FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch (IOException ex)
            {
                LogText("Input File in use by another program. \nFree it and try again");
                Console.WriteLine(ex.Message);
                return;
            }

            LogText("Initializing...");

            // Disable controls
            numRowOffset.Enabled = false;
            btnInputFile.Enabled = false;
            txtInputFile.Enabled = false;
            btnBegin.Enabled = false;
            chkNoScrape.Enabled = false;
            btnInputFile.Enabled = false;

            // The row offset needs to be subtracted by 1 for the header row and 1 for arrays starting at zero
            int offset = (int)numRowOffset.Value - 2;
            offset = offset > 0 ? offset : 0;

            // Setup the web class
            webWorker.SetRowOffset(offset); 
            webWorker.InputPath = txtInputFile.Text;

            webWorker.OutputPath = txtOutputFile.Text != "" ? txtOutputFile.Text : webWorker.OutputPath;

            // Create a thread to do the scraping in the background
            bufferWorker = new BackgroundWorker();

            bufferWorker.WorkerReportsProgress = true;
            bufferWorker.WorkerSupportsCancellation = true;

            bufferWorker.DoWork += BufferWorker_DoWork;
            //bufferWorker.RunWorkerCompleted += BufferWorker_RunWorkerCompleted;

            // Begin
            bufferWorker.RunWorkerAsync();

            LogText("Loading rows...");

            // Wait until some rows are loaded
            while (webWorker.recordBuffer.Count() <= 1)
            {
                Thread.Sleep(100);
            }

            LogText("Finished!");
            LogText("Ready for user input");

            // Allow user input
            LoadNextEntry();
        }

        /*private void BufferWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // LogText("Finished!");
            //LogText("Ready for user input");

            //LoadNextEntry();
        }*/

        private void BufferWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            webWorker.LoadBufferRows();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtNewDescription.TextLength > DESC_SIZE)
            {
                LogText("Text in the description box is too long!");
                return;
            }

            SaveCurrentEntry();
            LoadNextEntry();

            string time = DateTime.Now.ToString("h:mm tt");

            lblSaveTime.Text = time;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            txtNewBrand.Text = "";
            txtNewDescription.Text = "";
            txtNotes.Text = "Skipped - Cannot determine";

            button2_Click(sender, e);
        }

        private void chkNoScrape_CheckedChanged(object sender, EventArgs e)
        {
            webWorker.isOffline = chkNoScrape.Checked;
            LogText("Changed Offline to " + chkNoScrape.Checked.ToString() );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetLastEntry();
        }

        /// <summary>
        /// Handles the description size limit
        /// </summary>
        private void txtNewDescription_TextChanged(object sender, EventArgs e)
        {
            int len = txtNewDescription.TextLength;

            if (len > DESC_SIZE)
            {
                lblDescSize.BackColor = Color.Red;
            }
            else
            {
                lblDescSize.BackColor = Color.Transparent;
            }

            lblDescSize.Text = len + " of " + DESC_SIZE.ToString();
        }

        /// <summary>
        /// Loads the existing Company Product Description into the user-editable text boxes
        /// </summary>
        private void btnCarryOver_Click(object sender, EventArgs e)
        {

            if (chkAutoFormat.Checked == true)
            {
                txtNewDescription.Text = DescriptionFormat(txtDesc.Text);
            }
            else
            {
                txtNewDescription.Text = txtDesc.Text;
            }
        }

        /// <summary>
        /// Loads the existing Company Sign Description into the user-editable text boxes
        /// </summary>
        private void btnCarryOver2_Click(object sender, EventArgs e)
        {
            if (chkAutoFormat.Checked == true)
            {
                txtNewDescription.Text = DescriptionFormat(txtSignDesc.Text);
            }
            else
            {
                txtNewDescription.Text = txtSignDesc.Text;
            }
        }

        /// <summary>
        /// Loads the existing Company Brand into the user-editable text boxes
        /// </summary>
        private void btnCarryOverBrand_Click(object sender, EventArgs e)
        {
            if (chkAutoFormat.Checked == true)
            {
                txtNewBrand.Text = toTitlecase(txtBrand.Text);
            }
            else
            {
                txtNewBrand.Text = txtBrand.Text;
            }
        }

        /// <summary>
        /// Converts the given string to Title Case
        /// </summary>
        /// <returns>TitleCase'd string</returns>
        private string toTitlecase( string input )
        {
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;

            // Lowercase everything because ToTitleCase ignores all caps words
            input = input.ToLower();
            input = cultInfo.ToTitleCase(input);

            return input;
        }

        /// <summary>
        /// Formats an input string to remove unnecessary characters and fix capitalization
        /// </summary>
        /// <param name="input">Brand, description, etc</param>
        /// <returns>Formatted string</returns>
        private string DescriptionFormat(string input)
        {
            // Split the input by spaces
            string[] words = input.Split(' ');

            // Check to see if there are any common abbreviations that we recognize
            for(int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();

                if (webWorker.commonAbbreviations.ContainsKey(word))
                {
                    // Replace the abbreviation with the word
                    words[i] = webWorker.commonAbbreviations[word];
                }

            }

            // Form the array back into a string
            input = string.Join(" ", words);

            // Convert To Title Case
            input = toTitlecase(input);

            // Fix capitalization eg 12Th to 12th
            input = Regex.Replace(input, "[0-9][a-zA-Z]", m => m.ToString().ToLower());

            // Regex to remove any measures of weight (remove the extra backslashes to use on internet regex testers)
            input = Regex.Replace(input, "(([\\d]+\\.[\\d]+)|[\\d]+)[ ]?([oO][zZ]|[mM][lL]|[lL][bB]|[fF][lL]|[lL][tT]|[lL][iI][tT][eE][rR])[^a-zA-Z]", "");

            // Regex to remove the case/quantity format for cans and bottles
            input = Regex.Replace(input, "[\\d]+\\/[\\d]+ ?[cCbB]", "");

            // Remove HTML character codes ex &quot;
            input = Regex.Replace(input, "&.*;", "");

            // Remove empty parenthesis
            input = Regex.Replace(input, "\\(\\)", "");

            // One space between each word
            input = Regex.Replace(input, "  +", " ");

            // Change pack of 12 to 12-pack (doesn't appear to be substitute)
            input = Regex.Replace(input, "\\(? pack of([0 - 9] +)\\)?", "$&-pack", RegexOptions.IgnoreCase);

            // Remove the brand names
            input = Regex.Replace(input, txtBrand.Text, "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, txtNewBrand.Text, "", RegexOptions.IgnoreCase);

            // Replace hyphens
            input = Regex.Replace(input, " - ", " ");


            // Remove the year from wines
            //input = Regex.Replace(input, " 20[0-9][0-9] ", " ");

            // Remove excess white space from the boundaries
            input = input.Trim();

            return input;
        }

        private void btnFormatText_Click(object sender, EventArgs e)
        {
            txtNewBrand.Text = toTitlecase(txtNewBrand.Text);
            txtNewDescription.Text = DescriptionFormat(txtNewDescription.Text);
        }

        private void btnWebSearch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com/search?q=" + txtUPC.Text);
        }

        private void btnWebSearch2_Click(object sender, EventArgs e)
        {
            string searchDesc = txtSignDesc.Text;

            // Making the assumption that the longer description has more detail, so we google that
            if (txtDesc.TextLength > txtSignDesc.TextLength)
            {
                searchDesc = txtDesc.Text;
            }

            System.Diagnostics.Process.Start("https://www.google.com/search?q=" + txtBrand.Text + " " + searchDesc);
        }

        /// <summary>
        /// Function that allows for CTRL+A in the text boxes cause WinForms doesn't have functionality for that 
        /// </summary>
        private void selectAllEnabler(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                // Try to cast to a Text Box
                var obj = sender as TextBox;

                if (obj == null)
                {
                    // If the cast failed,  its a rich text box
                    if (sender != null)
                        ((RichTextBox)sender).SelectAll();
                }
                else
                {
                    // Otherwise its a regular text box
                    if (sender != null)
                        ((TextBox)sender).SelectAll();
                }

                e.Handled = e.SuppressKeyPress = true;
            }


            // Disable pressing the Enter key, really only necessary for the editable boxes
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Writes text to the rchBuffer component
        /// </summary>
        /// <param name="statement"></param>
        private void LogText(string statement)
        { 
            rchBuffer.AppendText(rchBuffer.Lines.Count().ToString() + ": " + statement + "\n");
            rchBuffer.ScrollToCaret();
        }

        private void btnAppendCan_Click(object sender, EventArgs e)
        {
            txtNewDescription.Text = txtNewDescription.Text.TrimEnd();
            txtNewDescription.AppendText(" Can");
        }

        private void btnAppendBottle_Click(object sender, EventArgs e)
        {
            txtNewDescription.Text = txtNewDescription.Text.TrimEnd();
            txtNewDescription.AppendText(" Bottle");
        }

        private void btnAppendPack_Click(object sender, EventArgs e)
        {
            txtNewDescription.Text = txtNewDescription.Text.TrimEnd();
            txtNewDescription.AppendText(" Pack");
        }
    }
}
