﻿using System;
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
<<<<<<< HEAD
<<<<<<< HEAD
=======
        //add search field
        /*
        public async Task<IActionResult> Index(string searchString)
        {
            using (LibraryMSContext mediaContext = new LibraryMSContext(options)) {
                var media = from m in mediaContext.Media
                            select m;
            }
>>>>>>> parent of c2f488a... added a search field in Catalog

            if (!String.IsNullOrEmpty(searchString))
            {
                media = media.Where(s => s.Title.Contains(searchString));
            }

            return View(await media.ToListAsync());
        }
        */
    }
=======

        public ActionResult AddMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMedia(MediaIndexListingModel model)
        {
            string title = model.Title;
            string author = model.Author;
            int id = model.Id;
            int mediaType = model.Type;
            string callnum = model.CallNum;
            return View();
        }
            //add search field
            /*
            public async Task<IActionResult> Index(string searchString)
            {
                using (LibraryMSContext mediaContext = new LibraryMSContext(options)) {
                    var media = from m in mediaContext.Media
                                select m;
                }

                if (!String.IsNullOrEmpty(searchString))
                {
                    media = media.Where(s => s.Title.Contains(searchString));
                }

                return View(await media.ToListAsync());
            }
            */
        }
>>>>>>> 3605b2987b700687bc0261da6bf3977c53189536
}