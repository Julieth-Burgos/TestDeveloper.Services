using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeveloper.Services.API.Extensions
{
    public static class Extensions
    {
        public static EstructureData<T> ContertToStructure<T>(this List<T> data) where T : class
        {
            return new EstructureData<T>(data);
        }
    }
}
