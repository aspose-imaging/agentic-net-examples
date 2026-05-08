using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.odg";
            string tempPath = "temp.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories exist for temporary and final output files
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the ODG image and rasterize it to a temporary PNG file
            using (Image odgImage = Image.Load(inputPath))
            {
                // Saving as PNG triggers rasterization of the vector ODG image
                odgImage.Save(tempPath);
            }

            // Load the rasterized PNG, apply median filter, and save the final PNG
            using (Image rasterImage = Image.Load(tempPath))
            {
                // Cast to RasterImage to access the Filter method
                var raster = (RasterImage)rasterImage;

                // Apply a median filter with size 5 to the entire image
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Save the filtered image as PNG
                raster.Save(outputPath);
            }

            // Clean up the temporary file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}