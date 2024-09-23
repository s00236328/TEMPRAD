using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1
{
     class Category
    {
        public int CategoryID;
        public string Description;
        public Category() { }

        public Category(int id, string description)
        {
            CategoryID = id;
            Description = description;
        }
    }
}
