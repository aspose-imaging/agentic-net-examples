using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.png";

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
                // Deskew the image (do not resize, use LightGray background)
                image.NormalizeAngle(false, Color.LightGray);

                // Verify transparency
                bool hasTransparency = image.HasAlpha || image.HasTransparentColor;
                Console.WriteLine($"Image has transparency: {hasTransparency}");

                // Save as PNG
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
 * 1. When a developer needs to correct the orientation of scanned TIFF documents, verify if they contain an alpha channel, and then provide a web‑friendly PNG version.
 * 2. When an application must automatically deskew TIFF invoices, check for transparency, and output them as lossless PNG files for downstream processing.
 * 3. When a batch‑processing service has to normalize the angle of TIFF images captured by a camera, detect any transparent pixels, and save the corrected images as PNG.
 * 4. When a document management system requires converting legacy TIFF scans to PNG after removing skew while ensuring transparent areas are identified for workflow decisions.
 * 5. When a C# utility needs to load a TIFF file, straighten it, determine if it uses transparency, and export the result as a PNG for display in a browser.
 */