using System;
using System.IO;
using System.Threading.Tasks;
using GildedRoseKata;
using VerifyXunit;
using Xunit;

namespace GildedRose.Tests
{
    public class ProgramTests
    {
        [Fact]
        public async Task VerifyProgramOutput()
        {
            using var writer = new StringWriter();
            Console.SetOut(writer);

            // Call the main method of the program
            // Provide the correct input to the Program.Main method
            // Adjust the input to simulate 20 days
            Program.Main(new string[] { "20" });

            // Capture the output
            var output = writer.ToString();

            // Debugging: Log the captured output
            Console.WriteLine("Captured Output:");
            Console.WriteLine(output);

            // Verify the output
            await Verifier.Verify(output);
        }
    }
}
