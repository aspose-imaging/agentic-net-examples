// HOW-TO: Convert ODG to PNG with White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage to access vector-specific properties
                var odgImage = (Aspose.Imaging.FileFormats.OpenDocument.OdgImage)image;

                // Optionally set a background color before rasterization
                odgImage.BackgroundColor = Color.White;

                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Save the rasterized image as PNG
                odgImage.Save(outputPath, pngOptions);
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
 * 1. When you need to rasterize an OpenDocument graphic (ODG) into a PNG for web display while ensuring a solid white background.
 * 2. When converting vector ODG files to PNG format in a .NET batch process that must create output folders automatically.
 * 3. When validating the existence of source ODG files before processing to avoid runtime errors in C# image conversion scripts.
 * 4. When integrating Aspose.Imaging into a C# application to programmatically load, modify (e.g., set background color), and export ODG drawings as PNG images.
 * 5. When handling image conversion in a server‑side service that requires safe disposal of resources using the using statement for Aspose.Imaging objects.
 */
