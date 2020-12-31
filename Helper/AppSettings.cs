using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Helper
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int MaxLoginFailedCount { get; set; }
        public int LoginFailedWaitingTime { get; set; }
    }
}
