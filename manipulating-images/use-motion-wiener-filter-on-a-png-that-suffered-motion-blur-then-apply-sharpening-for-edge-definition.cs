using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\blurred.png";
            string outputPath = @"C:\Images\processed.png";

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
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply Motion Wiener filter (size, sigma, angle)
                var motionOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);
                rasterImage.Filter(rasterImage.Bounds, motionOptions);

                // Apply Sharpen filter (kernel size, sigma)
                var sharpenOptions = new SharpenFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to restore a PNG screenshot captured from a moving presentation that appears blurred, they can apply a Motion‑Wiener filter followed by sharpening to make the text readable.
 * 2. When processing PNG images from a handheld scanner that were taken while the device moved, the code can reduce motion blur and enhance edge definition for better document archiving.
 * 3. When cleaning up security‑camera PNG frames that show a moving subject, the Motion‑Wiener filter and subsequent sharpen filter help reveal details for forensic analysis.
 * 4. When preparing product photos in PNG format taken with a shaky smartphone, developers can use this code to remove motion blur and sharpen edges before uploading to an e‑commerce site.
 * 5. When improving PNG medical scans (e.g., dermatology images) that suffered patient movement, applying the Motion‑Wiener filter and sharpening restores clarity for accurate diagnosis.
 */