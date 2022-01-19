using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthSample.Models
{
    public class JwtSetting
    {
        public string Issuer { set; get; }

        public string Audience { set; get; }

        public string SigningKey { set; get; }
    }
}
