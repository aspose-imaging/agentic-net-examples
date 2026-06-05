using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
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

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // If the image supports background removal, invoke it
                if (image is VectorImage vectorImg)
                {
                    vectorImg.RemoveBackground();
                }

                // Apply median filter to the entire image
                RasterImage rasterImg = (RasterImage)image;
                rasterImg.Filter(rasterImg.Bounds, new MedianFilterOptions(5));

                // Save the processed image
                rasterImg.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}