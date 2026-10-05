// HOW-TO: Convert ODG File to SVG Vector Format Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to display OpenDocument graphics on a web page, you can convert the ODG file to an SVG vector image in C#.
 * 2. When integrating a document workflow that receives ODG diagrams and must generate scalable graphics for printing, this code preserves the vector data during conversion.
 * 3. When building a batch processing tool that transforms a library of ODG assets into SVG for use in responsive UI components, the snippet automates the conversion.
 * 4. When a client requires loss‑less conversion of vector drawings from ODG to SVG to maintain editability in design software, this approach using Aspose.Imaging ensures fidelity.
 * 5. When creating a server‑side service that accepts ODG uploads and returns SVG thumbnails without rasterizing the image, the code provides a straightforward C# implementation.
 */
