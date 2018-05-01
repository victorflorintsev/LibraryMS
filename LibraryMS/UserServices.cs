using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LibraryMS.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using LibraryData;

namespace LibraryMS
{
    public class UserServices : IUsers
    {
        private cosc3380Context _context;
        private LibraryMSContext _mediacontext;
        public UserServices(cosc3380Context context, LibraryMSContext mediacontext)
        {
            _context = context;
            _mediacontext = mediacontext;
        }

        public void Add(Users newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }

        public List<Users> GetAll()
        {
            List<Users> outList = new List<Users>();
            foreach (Users u in _context.Users)
            {
                outList.Add(u);
            }

            return outList;
        }
        public Borrow checkout(int bookid, string username)
        {
            Borrow outBorrow = new Borrow();
            outBorrow.UserName = username;
            outBorrow.MediaId = bookid;
            outBorrow.IssueDate = DateTime.Today;
            outBorrow.DueDate = DateTime.Today.AddDays(10);
            outBorrow.Media = _context.Media.FirstOrDefault(asset => asset.MediaId == bookid);
            outBorrow.UserNameNavigation = _context.Users.FirstOrDefault(asset => asset.UserName == username);

            _context.Add(outBorrow);
            _context.SaveChangesAsync();
            return outBorrow;
        }


        public Users GetById(string username)
        {
            return _context.Users.FirstOrDefault(asset => asset.UserName == username);

        }

        public string getMediaTypeString(int id)
        {
            return _context.MediaType.FirstOrDefault(asset => asset.MediaTypeId == id).MediaTypeName;
        }

        public string getUserTypeString(int id)
        {
            return _context.UserType.FirstOrDefault(asset => asset.UserTypeId == id).UserTypeString;
        }

        public IEnumerable<Fine> GetFinesById(string username)
        {
            return _context.Fine.ToList().Where(asset => asset.UserName == username);
        }

        public bool IsEmployee(string username)
        {
            if (_context.Users.FirstOrDefault(asset => asset.UserName == username).UserType == (0 | 3))
            {
                return true;
            }
            return false;
        }
        public bool IsAdministrator(string username)
        {
            if (_context.Users.FirstOrDefault(asset => asset.UserName == username).UserType == 3)
            {
                return true;
            }
            return false;
        }


        public Media getMediaById(int id)
        {
            return _context.Media.FirstOrDefault(asset => asset.MediaId == id);
        }

        public void Update(Users updatedUser)
        {
            _context.Entry(updatedUser).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Borrow> GetBorrowedMediaById(string username)
        {
            return _context.Borrow.ToList().Where(asset => asset.UserName == username);
        }

        public IEnumerable<IsWaitlistedBy> GetHeldMediaById(string username)
        {
            IEnumerable<IsWaitlistedBy> outStuff = _context.IsWaitlistedBy.ToList().Where(asset => asset.UserName == username);
            foreach (IsWaitlistedBy w in outStuff)
            {
                int id = w.MediaId;
                LibraryData.LIBDBModels.Media intoW = _mediacontext.Media.FirstOrDefault(model => model.MediaId == id);
                Media outmedia = new Media();
                outmedia.Author = intoW.Author;
                outmedia.Title = intoW.Title;
                outmedia.Isbn = intoW.Isbn;
                outmedia.Genre = intoW.Genre;
                w.Media = outmedia;
            }
            return outStuff;
        }

        public void changeUserType(string id, int typeToChangeTo)
        {
            Users changedUser = _context.Users.FirstOrDefault(model => model.UserName == id);
            changedUser.UserType = typeToChangeTo;
            _context.Update(changedUser);
            _context.SaveChanges();
        }
    }
    }



