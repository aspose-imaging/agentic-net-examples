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
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access raster operations
                RasterImage raster = (RasterImage)image;

                // Increase brightness (value range -255 to 255)
                raster.AdjustBrightness(50);

                // Apply a 5x5 Gaussian blur; add a bias to keep the image brighter
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                blurOptions.Bias = 20; // increase overall brightness via kernel bias
                raster.Filter(raster.Bounds, blurOptions);

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When a developer needs to preprocess scanned BMP documents for OCR by brightening the image and reducing noise with a 5×5 Gaussian blur using Aspose.Imaging in a C# desktop application.
 * 2. When a game developer wants to programmatically enhance the visual quality of legacy BMP textures by increasing brightness and applying a subtle blur before loading them into Unity via C#.
 * 3. When an automation script must prepare BMP screenshots for a reporting system, adjusting brightness to compensate for dark monitors and smoothing details with a 5×5 blur using Aspose.Imaging for .NET.
 * 4. When a medical imaging software engineer needs to normalize the illumination of BMP X‑ray images and apply a mild blur to suppress high‑frequency artifacts before further analysis in C#.
 * 5. When a batch processing tool has to convert a folder of BMP assets, brighten each file and apply a consistent 5×5 Gaussian blur to achieve a uniform look across all images using Aspose.Imaging APIs.
 */