using System;
using System.IO;
using System.Threading.Tasks;
using GildedRoseKata;
using Shouldly;
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

        [Fact]
        public void Program_Main_WithNoArguments_ShouldHandleGracefully()
        {
            using var writer = new StringWriter();
            Console.SetOut(writer);
            Program.Main(new string[] { });
            var output = writer.ToString();
            output.ShouldNotBeNullOrWhiteSpace(); // Output should not be empty
            // Optionally, check for specific error or usage message
        }

        [Fact]
        public void Main_WithNoArguments_DoesNotThrow()
        {
            using var writer = new StringWriter();
            Console.SetOut(writer);

            Program.Main(new string[0]);

            var output = writer.ToString();
            output.ShouldContain("OMGHAI!"); // or any expected output for default days
        }
    }
}
