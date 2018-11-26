using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class UpTimeService
    {
        private Stopwatch timer;

        public UpTimeService()
        {
            timer = Stopwatch.StartNew();
        }

        public long UpTime => timer.ElapsedMilliseconds;
    }
}
