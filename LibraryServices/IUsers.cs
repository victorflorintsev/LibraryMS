
using LibraryData;
using LibraryData.LIBDBModels;
using System;
//using LibraryMS.LIBDBModels; //PROBLEMMA!
using System.Collections.Generic;



namespace LibraryServices
{
    public interface IUsers
    {
        //IEnumerable<Users> getAll();
        void Add(Users newMedia);
    }
}