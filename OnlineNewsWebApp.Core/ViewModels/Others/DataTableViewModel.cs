﻿namespace OnlineNewsWebApp.Core.ViewModels.Others
{
    public class DataTableViewModel
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int LastPage { get; set; }
        public string[] Columns { get; set; }
        public IList<Dictionary<string, string>> Data { get; set; }
    }
}
