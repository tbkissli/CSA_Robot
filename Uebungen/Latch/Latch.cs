using System;
using System.Threading;

namespace Latch {

    class Latch : ISynch {

        private ManualResetEvent mre = new ManualResetEvent(false);

        public void Acquire() {
            mre.WaitOne();
        }
        public void Release() {
            mre.Set();
        }
    }
}
