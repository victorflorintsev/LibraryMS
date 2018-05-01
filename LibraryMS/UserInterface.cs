using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMS
{
    public interface IUsers
    {
        string getMediaTypeString(int id);
        void Add(Users newUser);
        List<Users> GetAll();
        Users GetById(string username);
        IEnumerable<Fine> GetFinesById(string username);
        bool IsEmployee(string username);
        Borrow checkout(int bookid, string name);
        Media getMediaById(int id);
        string getUserTypeString(int id);
        void Update(Users updatedUser);
        IEnumerable<Borrow> GetBorrowedMediaById(string username);
        IEnumerable<IsWaitlistedBy> GetHeldMediaById(string username);
    }
}
