using LibraryData;
using System;
using LibraryData.LIBDBModels;
using System.Collections.Generic;

namespace LibraryServices
{
    public interface IUsers
    {
        IEnumerable<Users> getAll();
        void Add(Users newMedia);
    }
}