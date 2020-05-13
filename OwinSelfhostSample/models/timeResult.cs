using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OwinSelfhostSample.models
{
    public class timeResult
    {
        public long id { set; get; }
        public DateTime time { set; get; }
        public string remark { set; get; }
    }
}
