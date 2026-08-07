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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 800x600 using Bicubic (CubicConvolution) resampling
                image.Resize(800, 600, ResizeType.CubicConvolution);

                // Save as JPEG with default options
                var jpegOptions = new JpegOptions(); // default quality etc.
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded PNG graphics by resizing them to a standard 800 × 600 resolution with high‑quality bicubic resampling and then storing the result as a JPEG for faster delivery.
 * 2. When an e‑commerce platform must convert product images originally supplied as PNG files into optimized JPEG files of 800 × 600 pixels to meet the size requirements of a third‑party marketplace.
 * 3. When a desktop C# utility processes a batch of high‑resolution PNG screenshots, resizes each to 800 × 600 using the CubicConvolution algorithm, and saves them as JPEGs for inclusion in a PDF report.
 * 4. When a mobile backend service receives PNG icons from clients, needs to downscale them to 800 × 600 with bicubic interpolation to preserve visual quality, and stores the output as JPEG to reduce storage costs.
 * 5. When an automated build script for a digital signage system must convert source PNG assets to 800 × 600 JPEG images using Aspose.Imaging’s Resize method with bicubic resampling to ensure consistent display dimensions across all screens.
 */