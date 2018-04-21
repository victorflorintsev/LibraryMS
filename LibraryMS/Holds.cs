using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Holds
    {
        public int Id { get; set; }
        public DateTime HoldPlaced { get; set; }
        public int? LibraryAssetId { get; set; }
        public int? LibraryCardId { get; set; }

        public LibraryAssets LibraryAsset { get; set; }
        public LibraryCards LibraryCard { get; set; }
    }
}
