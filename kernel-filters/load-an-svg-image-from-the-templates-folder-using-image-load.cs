// HOW-TO: Load SVG Image From Templates Folder Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path to the SVG file in the templates folder
            string inputPath = "templates/sample.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG image using Aspose.Imaging.Image.Load
            using (Image image = Image.Load(inputPath))
            {
                // Example usage: output basic image information
                Console.WriteLine($"Loaded SVG image. Width: {image.Width}, Height: {image.Height}");
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to read an SVG file stored in a project’s templates directory to retrieve its dimensions for layout calculations.
 * 2. When you want to verify that an SVG asset exists before processing it in a .NET application.
 * 3. When you are building a reporting tool that extracts basic metadata such as width and height from vector graphics.
 * 4. When you need to load an SVG into memory with Aspose.Imaging to later convert it to another format like PNG or PDF.
 * 5. When you are debugging an image pipeline and need to quickly display the size of an SVG loaded from a known path.
 */
