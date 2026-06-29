using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.jpg";

        try
        {
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
                // Resize using Bicubic (CubicConvolution) resampling to 800x600
                image.Resize(800, 600, ResizeType.CubicConvolution);

                // Prepare JPEG save options (optional: set quality)
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded PNG photos at a fixed 800×600 size with high‑quality bicubic resampling before storing them as JPEGs for faster delivery.
 * 2. When an e‑commerce platform must convert product images from PNG to JPEG while resizing them to 800×600 pixels to meet the site’s image guidelines and reduce bandwidth.
 * 3. When a desktop utility processes a batch of PNG screenshots, resizes each to 800×600 using CubicConvolution interpolation, and saves them as high‑quality JPEG files for inclusion in a PDF report.
 * 4. When a mobile backend service receives PNG assets, needs to downscale them to 800×600 with bicubic filtering for consistent display on tablets, and stores the result as JPEG to optimize storage.
 * 5. When a content management system automatically prepares PNG graphics for email newsletters by resizing them to 800×600 pixels with bicubic resampling and converting them to JPEG to ensure compatibility with most email clients.
 */