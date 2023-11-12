using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10lib
{

    public interface IInit
    {
        void Init();
        void RandomInit();
    }

    public class SortByPrice : IComparer
    {
        int IComparer.Compare(object? obj1, object? obj2)
        {
            if(obj1 is null || obj2 is null)
                return 1;

            Goods goods1 = (Goods)obj1;
            Goods goods2 = (Goods)obj2;

            if (goods1.Price > goods2.Price)
                return 1;
            if (goods1.Price < goods2.Price)
                return -1;
            else
                return 0;
        }
    }


}
