using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryData;
using LibraryMS.Models.Media;
using LibraryMS.Views.Models.Media;

namespace LibraryMS.Controllers
{
    public class MediaController : Controller
    {
        private IMedia _assets;
        private readonly IUsers _userServices;
        public MediaController(IMedia assets, IUsers userServices)
        {
            _assets = assets;
            _userServices = userServices;
        }
        public IActionResult Index(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var foundMedia = _assets.SearchMedia(search);
                var foundListing = foundMedia.Select(r => new MediaIndexListingModel
                {
                    Id = r.MediaId,
                    Author = _assets.getAuthorOrDirector(r.MediaId),
                    Genre = _assets.getGenre(r.MediaId),
                    CallNum = _assets.getCallNum(r.MediaId),
                    Title = r.Title,
                    Type = _assets.getMediaType(r.MediaId)
                });

                var model1 = new MediaIndexModel()
                {
                    Assets = foundListing
                };
                return View(model1);
            }
            var assetModels = _assets.getAll();
            var listingResult = assetModels.Select(result => new MediaIndexListingModel
            {
                Id = result.MediaId,
                Author = _assets.getAuthorOrDirector(result.MediaId),
                Genre = _assets.getGenre(result.MediaId),
                CallNum = _assets.getCallNum(result.MediaId),
                Title = result.Title,
                Type = _assets.getMediaType(result.MediaId)
            });

            var model = new MediaIndexModel()
            {
                Assets = listingResult
            };
            return View(model);
        }

        public IActionResult ViewMedia(int id)
        {
            LibraryData.LIBDBModels.Media m = _assets.getbyID2(id);
            return View(m);
        }

        public IActionResult Checkout(int id)
        {
            int bookid = id;
            CheckoutModel toView = new CheckoutModel();
            toView.media = _assets.getbyID2(bookid);
            toView.borrow = _userServices.checkout(bookid, User.Identity.Name);
            return View(toView);
        }        

        public IActionResult AddMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMedia(MediaIndexListingModel model)
        {
            LibraryData.LIBDBModels.Media media = new LibraryData.LIBDBModels.Media();

            media.Title = model.Title;
            media.Author = model.Author;
            media.MediaId = model.Id;

            //LibraryData.LIBDBModels.MediaType type = new LibraryData.LIBDBModels.MediaType();
            //type.MediaTypeId = 0;
            //type.MediaTypeName = "Books";
            //media.MediaTypeNavigation = type;
            media.MediaType = model.Type;
            media.CallNum = model.CallNum;
            media.DateAdded = DateTime.Now;
            media.Genre = model.Genre;
            media.CopiesLeft = model.CopiesLeft;
            media.MaxCopies = model.CopiesLeft;
            media.Isbn = model.Isbn;
            _assets.Add(media);

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Media mediaToEdit = _userServices.getMediaById(id);
            return View(mediaToEdit);
            //return View(_context.Media.FirstOrDefault(asset => asset.MediaId == id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(LibraryData.LIBDBModels.Media media)
        {
            _assets.Update(media);

            return RedirectToAction("index");
               
        }

       
    }
}