// HOW-TO: Check Default FillMode of GraphicsPath Is Alternate in C# (Aspose.Imaging for .NET)
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Instantiate GraphicsPath
            var graphicsPath = new Aspose.Imaging.GraphicsPath();

            // Retrieve default FillMode
            var defaultFillMode = graphicsPath.FillMode;

            // Output the default FillMode
            Console.WriteLine($"Default FillMode: {defaultFillMode}");

            // Confirm it is Alternate
            if (defaultFillMode == Aspose.Imaging.FillMode.Alternate)
            {
                Console.WriteLine("FillMode is Alternate as expected.");
            }
            else
            {
                Console.WriteLine("FillMode is not Alternate.");
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
 * 1. When creating custom vector shapes with Aspose.Imaging, you may need to verify that the GraphicsPath starts with the Alternate fill mode to ensure correct winding rule for complex polygons.
 * 2. When converting raster images to vector paths, confirming the default FillMode helps avoid unexpected holes in filled regions during rendering.
 * 3. When debugging a drawing routine that relies on fill rules, checking the default FillMode lets you quickly determine if you must explicitly set it to NonZero.
 * 4. When building a PDF or SVG export feature, knowing the initial FillMode of a GraphicsPath ensures consistent appearance across different output formats.
 * 5. When writing unit tests for image processing libraries, asserting that GraphicsPath.FillMode equals Alternate validates the library’s default behavior.
 */
