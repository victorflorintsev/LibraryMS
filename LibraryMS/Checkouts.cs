using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Checkouts
    {
        public int Id { get; set; }
        public int LibraryAssetId { get; set; }
        public int? LibraryCardId { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }

        public LibraryAssets LibraryAsset { get; set; }
        public LibraryCards LibraryCard { get; set; }
    }
}
