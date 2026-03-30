using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage (Aspose.Imaging rasterizes the SVG on demand)
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur filter (size = 5, sigma = 4.0)
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Verify that no pixel intensity exceeds 255
            int[] argbPixels = rasterImage.LoadArgb32Pixels(rasterImage.Bounds);
            bool intensityOk = true;
            foreach (int argb in argbPixels)
            {
                // Extract R, G, B components (ignore Alpha)
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;

                if (r > 255 || g > 255 || b > 255)
                {
                    intensityOk = false;
                    break;
                }
            }

            if (!intensityOk)
            {
                Console.WriteLine("Pixel intensity exceeds 255 after Gaussian blur.");
            }
            else
            {
                Console.WriteLine("All pixel intensities are within the 0-255 range.");
            }

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}