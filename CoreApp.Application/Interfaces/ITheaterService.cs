using CoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Application.Interfaces
{
    public interface ITheaterService
    {
        List<Theater> GetAllTheater();
        List<Theater> GetAllTheaterChild(int Id);
    }
}
