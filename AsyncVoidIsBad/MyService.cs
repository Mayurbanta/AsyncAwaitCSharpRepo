using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncVoidIsBad
{
    public class MyService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyService"/> class.
        /// https://www.nuget.org/packages/AsyncAwaitBestPractices/
        /// </summary>
        public MyService()
        {
            //DoSomething();
            DoSomething().Await(CompletedTask, HandleError);
        }

        private void CompletedTask()
        {
            throw new NotImplementedException();
        }

        private void HandleError(Exception ex)
        {
            throw new NotImplementedException();
        }

        public async Task DoSomething()
        {
            await Task.Delay(2000);
            throw new Exception("Exception in DoSomething()");
        }

    }

  
}
