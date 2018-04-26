using LibraryData;
using System;
using LibraryData.LIBDBModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryServices
{
    public class MediaServices : IMedia
    {
        private LibraryMSContext _context;
        public MediaServices(LibraryMSContext context)
        {
            _context = context;
        }

        public void Add(Media newMedia)
        {
            _context.Add(newMedia);
            _context.SaveChanges();
        }

        public IEnumerable<Media> getAll()
        {
            return _context.Media;
        }

        public string getAuthorOrDirector(int id)
        {
            return _context.Media.FirstOrDefault(a => a.MediaId == id).Author;
        }

        public string getGenre(int id)
        {
            return _context.Media.FirstOrDefault(a => a.MediaId == id).Genre;
        }

        public Media getbyID(int id)
        {
            return _context.Media.Include(asset=>asset.Title).Include(asset => asset.MediaType).FirstOrDefault(asset => asset.MediaId == id);   
        }

        public Media getbyID2(int id)
        {
            return _context.Media.FirstOrDefault(asset => asset.MediaId == id);
        }

        public string getCallNum(int id)
        {

            if (_context.Media.Any(a => a.MediaId == id))
            {
                return _context.Media.FirstOrDefault(a => a.MediaId == id).CallNum;
            }
            else
                return "";
        }

        public int getCopiesLeft(int id)
        {
            return _context.Media.FirstOrDefault(a => a.MediaId == id).CopiesLeft;
        }

        public DateTime getDateAdded(int id)
        {
                return _context.Media.FirstOrDefault(a => a.MediaId == id).DateAdded;
        }

        public int getISBN(int id)
        {
            if (_context.Media.Any(a => a.MediaId == id))
            {
                return _context.Media.FirstOrDefault(a => a.MediaId == id).Isbn;
            }
            else
                return 0;
        }

        public int getMaxCopies(int id)
        {
            return _context.Media.FirstOrDefault(a => a.MediaId == id).MaxCopies;
        }

        public int getMediaType(int id)
        {
            return _context.Media.FirstOrDefault(a => a.MediaId == id).MediaType;
        }

        public string getTitle(int id)
        {
            return _context.Media.FirstOrDefault(a => a.MediaId == id).Title;
        }

        public List<Media> SearchMedia(string search)
        {
            return _context.Media
                .Where(m => m.Title.Contains(search) || m.Author.Contains(search)).ToList();
        }
    }
}
