using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image from the HTML5 canvas (e.g., PNG)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access AdjustGamma
                if (image is RasterImage rasterImage)
                {
                    // Apply gamma correction of 2.2
                    rasterImage.AdjustGamma(2.2f);
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image format for gamma adjustment.");
                    return;
                }

                // Set JPEG save options with quality 90
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                // Save the processed image as JPEG
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
 * 1. When a web application needs to convert a user‑drawn HTML5 canvas PNG into a high‑quality JPEG for email attachments, applying gamma correction with Aspose.Imaging for .NET to preserve visual brightness.
 * 2. When an e‑commerce platform processes product images uploaded from a canvas editor, using C# to adjust gamma to 2.2 and save them as JPEGs with 90 % quality for SEO‑friendly image delivery.
 * 3. When a digital asset management system batch‑converts canvas screenshots to JPEG while applying gamma correction to ensure consistent display across different monitors.
 * 4. When a mobile backend service receives PNG images from an HTML5 canvas, applies sRGB gamma correction and stores them as compressed JPEGs with quality 90 using Aspose.Imaging.
 * 5. When a reporting tool generates charts on an HTML5 canvas and must export them as JPEGs with proper gamma adjustment and high quality for inclusion in PDF reports.
 */