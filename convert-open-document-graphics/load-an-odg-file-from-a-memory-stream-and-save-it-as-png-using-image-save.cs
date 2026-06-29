using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.odg";
            string outputPath = @"C:\Temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load ODG file into a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                // Load the image from the memory stream
                using (Image image = Image.Load(ms))
                {
                    // Cast to OdgImage for ODG-specific handling (optional)
                    OdgImage odgImage = image as OdgImage;

                    // Prepare PNG save options
                    PngOptions pngOptions = new PngOptions();

                    // Save the image as PNG to the specified file
                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When a developer needs to convert an OpenDocument Graphics (ODG) file received in a memory stream into a PNG thumbnail for display in a web gallery using Aspose.Imaging.
 * 2. When a backend service must transform ODG drawings stored as byte arrays into PNG images before uploading them to cloud storage.
 * 3. When a batch job processes a directory of ODG diagrams, loading each via Image.Load and saving them as PNG files for inclusion in generated PDF reports.
 * 4. When server‑side code renders user‑uploaded ODG vector graphics to PNG format so they can be embedded in email newsletters that only support raster images.
 * 5. When an application needs to provide browser‑compatible previews by converting ODG files to PNG using C# MemoryStream and PngOptions.
 */