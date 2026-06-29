using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image with default options
            using (Image image = Image.Load(inputPath))
            {
                // Example: save the loaded image as PNG (optional)
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a vector EPS file received from a designer into a raster PNG for web display, they can load the EPS with Image.Load and save it as PNG.
 * 2. When an automated batch job must validate that an EPS asset exists before processing it, the code checks the file, loads it with default options, and optionally writes a PNG preview.
 * 3. When integrating a legacy printing workflow that supplies EPS logos, a C# service can use Aspose.Imaging to load the EPS and generate a PNG thumbnail for UI galleries.
 * 4. When building a document conversion tool that extracts embedded EPS images and stores them as PNGs for downstream PDF generation, the developer can employ Image.Load with default settings.
 * 5. When troubleshooting image rendering issues, a developer can quickly load an EPS file using Aspose.Imaging and save it as PNG to compare the raster output against expected results.
 */