using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class CheckoutHistories
    {
        public int Id { get; set; }
        public DateTime? CheckedIn { get; set; }
        public DateTime CheckedOut { get; set; }
        public int LibraryAssetId { get; set; }
        public int LibraryCardId { get; set; }

        public LibraryAssets LibraryAsset { get; set; }
        public LibraryCards LibraryCard { get; set; }
    }
}
