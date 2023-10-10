using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.Services;

namespace UnitTesting.Tests
{
    internal static class WorldDumbestFunctionTest
    {
        //Naming Convention - ClassName_MethodName_ExpectedResult
        public static void WorldDumbestFunction_ReturnsPikachuIfZero_ReturnsPikachu()
        {
            try
            {
                //Arrange - Go get variables, whatever, your classes, etc.
                int num = 0;
                WorldDumbestFunction worldDumbestFunction = new WorldDumbestFunction();

                //Act - Execute this function
                string result = worldDumbestFunction.ReturnsPikachuIfZero(num);

                //Assert - Whatever is returned from the function, is it what we expected?
                if (result == "Pikachu")
                {
                    Console.WriteLine("PASSED: WorldDumbestFunction_ReturnsPikachuIfZero_ReturnsPikachu");
                }
                else
                {
                    Console.WriteLine("FAILED: WorldDumbestFunction_ReturnsPikachuIfZero_ReturnsPikachu");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
