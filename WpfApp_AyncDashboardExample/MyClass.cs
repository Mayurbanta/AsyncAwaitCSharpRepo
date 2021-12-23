using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_AyncPatientChart
{
    class MyClass
    {
        #region Regular Methods
        public string Block1Data()
        {
            SlowDownMethod(1);
            return "B-1 Data";
        }

        public string Block2Data()
        {
            SlowDownMethod(1);
            return "B-2 Data";
        }

        public string Block3Data()
        {
            SlowDownMethod(1);
            return "B-3 Data";
        }

        public string Block4Data()
        {
            SlowDownMethod(1);
            return "B-4 Data";
        }

        #endregion

        #region Async Methods
        public Task<string> Block1DataAsync()
        {

            return Task.Run<string>(() => Block1Data());
        }

        public Task<string> Block2DataAsync()
        {

            return Task.Run<string>(() => Block2Data());
        }
        public Task<string> Block3DataAsync()
        {

            return Task.Run<string>(() => Block3Data());
        }
        public Task<string> Block4DataAsync()
        {

            return Task.Run<string>(() => Block4Data());
        }

        #endregion


        public void SlowDownMethod(int sec)
        {
            var endDateTime = DateTime.Now + TimeSpan.FromSeconds(sec);
            while (DateTime.Now < endDateTime)
                /* nothing here */
                ;
        }
    }
}
