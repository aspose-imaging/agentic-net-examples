// HOW-TO: Convert ODG to JPEG With 85% Quality In C# (Aspose.Imaging for .NET)
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
            string inputPath = "sample.odg";
            string outputPath = "sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with quality 85
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 85
                };

                // If the source is a vector image, set rasterization options
                if (image is VectorImage)
                {
                    var rasterOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    };
                    jpegOptions.VectorRasterizationOptions = rasterOptions;
                }

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate a high‑quality preview image from an OpenDocument graphics (ODG) file for web display.
 * 2. When converting vector‑based ODG drawings to raster JPEGs for inclusion in reports or email attachments.
 * 3. When you must ensure consistent JPEG compression by setting the quality level to 85 percent during batch processing.
 * 4. When an application must rasterize ODG pages with a white background before saving them as JPEG files.
 * 5. When automating a workflow that validates the existence of source ODG files and creates the required output folder structure before conversion.
 */
