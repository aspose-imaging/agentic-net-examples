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
            string blurredPath = @"C:\Images\blurred.png";
            string outputPath = @"C:\Images\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(blurredPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with sigma 1.2 (kernel size 5)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 1.2));
                // Save the blurred image
                rasterImage.Save(blurredPath);

                // Apply Gaussian deconvolution (Gauss-Wiener) with matching kernel
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 1.2));
                // Save the final deconvolved image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}