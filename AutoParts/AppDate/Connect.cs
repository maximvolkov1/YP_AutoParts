using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.AppDate
{
    internal class Connect
    {
        public static AutoPartsDBEntities1 context;
        public static AutoPartsDBEntities1 GetCont()
        {
            if (context == null) context = new AutoPartsDBEntities1();
            return context;
        }
    }
}
