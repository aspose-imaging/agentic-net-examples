// HOW-TO: Load and Re‑Save a PNG File with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions();
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
 * 1. When you need to verify that a PNG image can be opened and saved without corruption using Aspose.Imaging in a C# application.
 * 2. When you want to copy or duplicate a PNG file to a new location while automatically creating the destination folder in .NET.
 * 3. When you are building a preprocessing step that normalizes PNG files before further processing, such as applying filters or resizing.
 * 4. When you need to programmatically ensure an input PNG exists and handle missing‑file errors gracefully in a C# service.
 * 5. When you are integrating Aspose.Imaging into a batch job that reads PNGs, performs operations, and writes them back with consistent PNG encoding options.
 */
