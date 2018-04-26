using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Views.Models.Media
{
    public class CheckoutModel
    {
        public Borrow borrow { get; set; }
        public LibraryData.LIBDBModels.Media media { get; set; }
    }
}
