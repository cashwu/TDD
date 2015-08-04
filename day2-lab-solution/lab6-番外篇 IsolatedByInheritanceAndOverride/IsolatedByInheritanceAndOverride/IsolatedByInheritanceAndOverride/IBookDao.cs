using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsolatedByInheritanceAndOverride
{
    public interface IBookDao
    {
        void Insert(Order order);
    }
}
