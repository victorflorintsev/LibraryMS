﻿using System;
using System.Collections.Generic;

namespace LibraryData.LIBDBModels
{
    public partial class MediaType
    {

        public int MediaTypeId { get; set; }
        public string MediaTypeName { get; set; }

        public Media Media { get; set; }
    }
}
