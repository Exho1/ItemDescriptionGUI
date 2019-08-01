using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace ItemDescriptionGUI
{
    /// <summary>
    /// Class containing all the columns of the input CSV as public members
    /// </summary>
    public class CSVRow
    {
        public string desc { get; set; }
        public string brand { get; set; }
        public string notes { get; set; }
        public string full_upc { get; set; }
        public string brand2 { get; set; }
        public string desc2 { get; set; }
        public string pos { get; set; }
        public string sign { get; set; }
        public string size { get; set; }
    }

    /// <summary>
    /// Maps the column names to the class members
    /// </summary>
    public sealed class InputMap : ClassMap<CSVRow>
    {
        public InputMap()
        {
            Map(m => m.desc).Name("HOME SHOPPING DESCRIPTION");
            Map(m => m.brand).Name("BRAND").NameIndex(0);
            Map(m => m.notes).Name("Notes").NameIndex(0);
            Map(m => m.full_upc).Name("FULL_UPC");
            Map(m => m.brand2).Name("BRAND").NameIndex(1);
            Map(m => m.desc2).Name("PRODUCT_DESCRIPTION");
            Map(m => m.pos).Name("POS_DESCRIPTION");
            Map(m => m.sign).Name("SIGN_DESCR");
            Map(m => m.size).Name("ITEM_SIZE");
        }
    }

    /// <summary>
    /// Class that holds the returned string from the web scraper for the given UPC
    /// </summary>
    public class ScraperOutput
    {
        /// <summary>
        /// String of text returned by the web scraper
        /// </summary>
        public string desc;
        public string upc;
    }

}
