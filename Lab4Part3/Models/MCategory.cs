using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel
{
    public class MCategory
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MProduct> Products { get; set; }

        
    }
}
