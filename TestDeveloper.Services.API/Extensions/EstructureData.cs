using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeveloper.Services.API.Extensions
{
    public class EstructureData<T>
    {
        public EstructureData(List<T> data)
        {
            if (data == null)
            {
                this.data = new List<T>();
                return;
            }

            this.data = data;
        }

        public List<T> data { get; set; }
    }
}
