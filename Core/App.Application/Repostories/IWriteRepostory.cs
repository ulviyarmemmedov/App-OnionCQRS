using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Repostories
{
    public interface IWriteRepostory<T> where T:class,IQueryable
    {
    }
}
