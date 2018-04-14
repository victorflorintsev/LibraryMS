using System;
using System.Collections.Generic;

namespace LibraryData.LIBDBModels
{
    public class Section
    {
        public int SectionId { get; set; }
        public string LocationString { get; set; }
        public string SectionName { get; set; }
        public string StartCallNum { get; set; }
        public string EndCallNum { get; set; }
    }
}
