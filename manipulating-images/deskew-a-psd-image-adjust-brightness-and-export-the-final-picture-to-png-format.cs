using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.psd";
        string outputPath = @"C:\Images\output.png";

        try
        {
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
                // Cast to RasterImage to access processing methods
                var raster = image as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Deskew the image (normalize angle)
                raster.NormalizeAngle();

                // Adjust brightness (value can be changed as needed)
                raster.AdjustBrightness(20);

                // Prepare PNG save options
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Save the processed image as PNG
                raster.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to automatically deskew scanned Photoshop (PSD) files, boost their brightness, and generate web‑optimized PNG thumbnails for faster loading.
 * 2. When a batch‑processing script must straighten misaligned PSD artwork, enhance visibility with brightness adjustment, and save the results as PNG images for archival.
 * 3. When an e‑commerce platform preprocesses product mockups in PSD format, corrects tilt, increases brightness, and converts them to PNG for display on product pages.
 * 4. When a digital asset management system imports user‑uploaded PSD designs, normalizes the angle, improves brightness, and creates PNG previews for quick browsing.
 * 5. When a desktop utility converts legacy Photoshop PSD assets into PNG files for mobile apps, ensuring the images are level and properly brightened.
 */