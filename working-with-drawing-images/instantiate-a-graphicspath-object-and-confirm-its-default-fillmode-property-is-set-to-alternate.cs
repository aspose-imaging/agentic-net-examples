// HOW-TO: Check Default FillMode of GraphicsPath Is Alternate in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            if (graphicsPath.FillMode == FillMode.Alternate)
            {
                Console.WriteLine("Default FillMode is Alternate.");
            }
            else
            {
                Console.WriteLine($"Default FillMode is {graphicsPath.FillMode}.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When creating custom vector shapes with Aspose.Imaging, you may need to verify that a new GraphicsPath starts with the Alternate fill mode before applying complex fill rules.
 * 2. When debugging rendering differences between overlapping polygons, checking the default FillMode helps ensure consistent winding behavior across platforms.
 * 3. When migrating legacy code that relied on the default FillMode, you can use this snippet to confirm the Aspose.Imaging GraphicsPath still defaults to Alternate.
 * 4. When implementing custom clipping regions for PDF or raster images, confirming the initial FillMode prevents unexpected gaps in the clipped area.
 * 5. When writing unit tests for image processing libraries, asserting the default FillMode of GraphicsPath guarantees that subsequent drawing operations behave as expected.
 */
