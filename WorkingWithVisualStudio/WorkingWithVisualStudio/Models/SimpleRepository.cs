using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository SharedRepository => new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public SimpleRepository()
        {
            var InitialItems = new[]
            {

            };
        }
        
    }
}
