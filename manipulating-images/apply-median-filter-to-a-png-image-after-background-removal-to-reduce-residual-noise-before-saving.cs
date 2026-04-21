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
            string inputPath = "c:\\temp\\input.png";
            string outputPath = "c:\\temp\\output.png";

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
                // Remove background if the image supports it
                if (image is VectorImage vectorImg)
                {
                    vectorImg.RemoveBackground();
                }

                // Apply median filter to reduce residual noise
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

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