
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, string documento)
        {
            return Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}