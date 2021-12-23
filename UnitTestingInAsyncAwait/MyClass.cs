using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingInAsyncAwait
{
    public class MyClass
    {
        public async Task<string> DoSomething()
        {
            await Task.Delay(2000);
            return "some string";
        }

        [TestMethod]
        public async Task DoSomething_TestAsyncMethod() 
        {
            //Arrange

            //Act
          var result  =  await DoSomething();

            //Assert
            //Assert.That(result.IsNormalized().Not.Null);

        }
    }
}
