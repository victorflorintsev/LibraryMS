using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData;
using LibraryMS.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMS.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomer _assets;
        public CustomerController(ICustomer assets)
        {
            _assets = assets;
        }
        public IActionResult Index()
        {
            var assetModels = _assets.getAll();
            var listingResult = assetModels.Select(result => new CustomerIndexListingModel
            {
                Id = result.CustomerId,
                first_name=_assets.getFirst(result.CustomerId),
                last_name = _assets.getLast(result.CustomerId)

            });

            var model = new CustomerIndexModel()
            {
                Assets = listingResult
            };
            return View(model);
        }
    }
}