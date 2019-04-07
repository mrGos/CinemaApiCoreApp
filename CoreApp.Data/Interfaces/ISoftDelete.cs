using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Data.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { set; get; }
    }
}
