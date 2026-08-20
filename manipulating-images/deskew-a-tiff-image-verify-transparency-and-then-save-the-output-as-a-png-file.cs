// HOW-TO: Deskew TIFF Image, Check Transparency, and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.tif";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image (normalize angle) without resizing, using LightGray background
                image.NormalizeAngle(false, Color.LightGray);

                // Verify transparency (alpha channel)
                bool hasTransparency = image.HasAlpha;
                Console.WriteLine($"Image has transparency: {hasTransparency}");

                // Save the result as PNG
                var pngOptions = new PngOptions();
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
 * 1. When you need to correct the rotation of scanned TIFF documents before converting them to web‑friendly PNG files.
 * 2. When you must ensure a scanned image retains its alpha channel information so transparent regions are preserved during format conversion.
 * 3. When an automated batch process has to normalize the angle of TIFF images from a scanner and output them as PNG for downstream graphics pipelines.
 * 4. When a document management system requires deskewed TIFF pages with verified transparency before storing them as lossless PNG assets.
 * 5. When integrating Aspose.Imaging in a C# application to preprocess TIFF files—removing skew, checking for transparency, and saving the result as PNG for UI display.
 */
