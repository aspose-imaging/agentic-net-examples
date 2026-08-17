// HOW-TO: Resize PNG to 800x600 with Bicubic Resampling and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 800x600 using Bicubic (CubicConvolution) resampling
                image.Resize(800, 600, ResizeType.CubicConvolution);

                // Prepare JPEG save options (default quality)
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 100
                };

                // Save the resized image as JPEG
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
 * 1. When you need to generate a web‑ready JPEG thumbnail from a high‑resolution PNG for faster page loads.
 * 2. When an e‑commerce platform requires product images in a fixed 800×600 JPEG size while preserving quality using bicubic resampling.
 * 3. When converting user‑uploaded PNG screenshots to JPEG for email attachments that have size limits.
 * 4. When preparing assets for a mobile app that only supports JPEG at a specific resolution, ensuring consistent dimensions.
 * 5. When automating a batch process that standardizes legacy PNG graphics to 800×600 JPEG files for archival storage.
 */
