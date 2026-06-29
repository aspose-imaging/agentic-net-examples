using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\source.eps";
            string outputPath = @"C:\Images\output\cropped.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                // Define crop rectangle (example: central half of the image)
                int cropX = image.Width / 4;
                int cropY = image.Height / 4;
                int cropWidth = image.Width / 2;
                int cropHeight = image.Height / 2;
                var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                // Crop the image
                image.Crop(cropRect);

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
 * 1. When a developer needs to extract a specific region from a vector EPS logo and deliver it as a raster PNG for web display.
 * 2. When an automated pipeline must convert large EPS artwork into smaller PNG thumbnails by cropping the central area.
 * 3. When a print‑to‑screen preview tool requires loading an EPS file, trimming unwanted margins, and saving the result as a PNG for UI rendering.
 * 4. When a batch job processes incoming EPS design files, removes excess whitespace by cropping, and stores the cleaned images as PNGs for downstream processing.
 * 5. When a C# application integrates Aspose.Imaging to read EPS files, apply a rectangular crop to focus on a product label, and export the cropped image as PNG for inclusion in a catalog.
 */