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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply motion blur (size 2, smooth 1.0, angle 0)
                var motionOptions = new MotionWienerFilterOptions(2, 1.0, 0.0);
                rasterImage.Filter(rasterImage.Bounds, motionOptions);

                // Apply sharpen filter (kernel size 3, sigma 1.0)
                var sharpenOptions = new SharpenFilterOptions(3, 1.0);
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
 * 1. When a developer needs to clean up a scanned technical drawing in PNG format by reducing motion artifacts and enhancing edge definition before archiving it.
 * 2. When an engineering application must automatically preprocess CAD export images with a subtle motion blur followed by a 3×3 sharpen filter to improve visual clarity for end‑users.
 * 3. When a batch job processes architectural blueprint PNG files, applying a size‑2 motion‑wiener filter and a 3‑pixel sharpen kernel to prepare them for printing.
 * 4. When a C# service integrates Aspose.Imaging to normalize hand‑drawn sketches by smoothing motion blur and sharpening details prior to feeding them into a machine‑learning model.
 * 5. When a desktop utility needs to load a raster image, apply sequential motion blur and sharpen filters, and save the result as a new PNG for documentation purposes.
 */