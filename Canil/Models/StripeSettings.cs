using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Models
{
    public class StripeSettings
    {
        public string PublicKey { get; set; }
        public string SecretKey { get; set; }
    }
}