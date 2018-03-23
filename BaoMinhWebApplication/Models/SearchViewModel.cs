using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BaoMinhWebApplication.Models
{
    public class SearchViewModel
    {
        public bool isEmpty { get; set; }
        public bool isFirstPage { get; set; }
        public bool isLastPage { get; set; }

    }

    public class FilterViewModel
    {
        public string label { get; set; }
        public string value { get; set; }
        public string name { get; set; }
    }
}