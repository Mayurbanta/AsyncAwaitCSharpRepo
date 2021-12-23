using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncVoidIsBad
{
   public static class TaskExtensions
    {
        public async static void Await(this Task task,Action completedCallback, Action<Exception> errorCallback)
        {
            try
            {
                await task;
                completedCallback?.Invoke();
            }
            catch (Exception ex)
            {

                errorCallback?.Invoke(ex);
            }
        }
    }
}
