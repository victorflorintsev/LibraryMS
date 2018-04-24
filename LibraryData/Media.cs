using System;
using System.Collections.Generic;
using LibraryData.LIBDBModels;
using System.Text;

namespace LibraryData
{
   public interface IMedia
    {
        //int id is the primary key
        IEnumerable<Media> getAll(); 
        Media getbyID(int id);
        void Add(Media newMedia);
        string getAuthorOrDirector(int id);
        string getTitle(int id);
        int getISBN(int id);
        int getMediaType(int id);
        string getGenre(int id);
        string getCallNum(int id);
        DateTime getDateAdded(int id);
        int getCopiesLeft(int id);
        int getMaxCopies(int id);
        List<Media> SearchMedia(string search);


        //steps to make MVC to fucking work
        //1->LibraryData Interface
        //Services
        //2->Controller
        //3->Models Listing
        //4->cshtml
        //5->add mvc on startup
    }
}
