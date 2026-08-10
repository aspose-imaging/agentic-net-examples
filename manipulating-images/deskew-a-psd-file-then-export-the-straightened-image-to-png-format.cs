// HOW-TO: How To Deskew A PSD And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.psd";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to use NormalizeAngle (deskew)
                if (image is RasterImage rasterImage)
                {
                    // Deskew without resizing, using LightGray as background
                    rasterImage.NormalizeAngle(false, Color.LightGray);
                }

                // Prepare PNG save options (default options are sufficient)
                PngOptions pngOptions = new PngOptions();

                // Save the straightened image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When you receive scanned Photoshop PSD files that are slightly rotated and need a correctly oriented PNG for web display.
 * 2. When an automated batch job must correct the tilt of PSD layers before converting them to PNG thumbnails.
 * 3. When a document management system stores original PSD artwork and you need to generate straightened PNG previews for quick viewing.
 * 4. When a digital asset pipeline requires deskewed PNG exports from PSD sources to maintain consistent layout in mobile apps.
 * 5. When you want to programmatically remove skew from a PSD image and save the result as a lossless PNG without resizing.
 */
