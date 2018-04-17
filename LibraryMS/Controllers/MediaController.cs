using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryData;
using LibraryMS.Models.Media;

namespace LibraryMS.Controllers
{
    public class MediaController : Controller
    {
        
        private IMedia _assets;
        public MediaController(IMedia assets)
        {
            _assets = assets;
        }
        public IActionResult Index()
        {
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

        public IActionResult AddMedia()
        {
            return View();
        }
    }
}