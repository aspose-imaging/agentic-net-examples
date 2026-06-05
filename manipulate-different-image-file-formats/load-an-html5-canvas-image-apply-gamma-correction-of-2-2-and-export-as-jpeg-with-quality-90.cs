using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\canvas.png";
        string outputPath = @"C:\Images\canvas_gamma.jpg";

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

            // Load the image (HTML5 canvas exported as PNG/JPEG/etc.)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access AdjustGamma
                if (image is RasterImage rasterImage)
                {
                    // Apply gamma correction of 2.2 to all channels
                    rasterImage.AdjustGamma(2.2f);
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image format for gamma adjustment.");
                    return;
                }

                // Set JPEG options with quality 90
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
 * 1. When a web application exports an HTML5 canvas drawing as PNG and needs to correct its brightness using gamma 2.2 before storing it as a high‑quality JPEG for archival.
 * 2. When a C# service processes user‑generated graphics from an HTML5 canvas, applies gamma correction to match display standards, and saves the result as a JPEG with 90 % quality for email attachments.
 * 3. When a desktop utility built with Aspose.Imaging loads a canvas‑exported image, adjusts its gamma to 2.2 to improve contrast, and outputs a JPEG optimized for web publishing.
 * 4. When an automated batch job reads PNG files created from HTML5 canvas elements, performs gamma correction, and converts them to JPEG files with a specific quality setting for a content‑delivery network.
 * 5. When a photo‑editing plugin for a .NET application needs to import a canvas image, apply gamma correction to ensure consistent color reproduction, and export it as a JPEG with quality 90 for printing workflows.
 */