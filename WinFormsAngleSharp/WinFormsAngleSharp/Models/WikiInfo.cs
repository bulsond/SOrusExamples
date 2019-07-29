using System.Collections.Generic;

namespace WinFormsAngleSharp.Models
{
    class WikiInfo
    {
        public string Header { get; set; }
        public List<string> Paragraphs { get; private set; }

        //ctor
        public WikiInfo()
        {
            Paragraphs = new List<string>();
        }
    }
}
