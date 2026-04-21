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
                // Cast to RasterImage for filter operations
                RasterImage rasterImage = (RasterImage)image;

                // 1. Apply automatic adaptive brightness/contrast normalization.
                // This step equalizes local brightness and contrast, providing a consistent baseline.
                rasterImage.AutoBrightnessContrast();

                // 2. Apply a sharpen filter to enhance edges.
                // Using default kernel size and sigma; these values are chosen to avoid over‑enhancement.
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // 3. Normalize histogram after sharpening.
                // This restores the overall brightness range that may have shifted during sharpening.
                rasterImage.NormalizeHistogram();

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