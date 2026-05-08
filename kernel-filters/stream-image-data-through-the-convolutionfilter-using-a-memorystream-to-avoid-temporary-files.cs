using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\sample.png";
            string outputPath = "output\\sample_filtered.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image data into a memory stream
            byte[] imageBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (Image image = Image.Load(ms))
                {
                    RasterImage raster = (RasterImage)image;

                    // Apply Gaussian blur filter using ConvolutionFilterOptions
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0);
                    raster.Filter(raster.Bounds, filterOptions);

                    // Save the filtered image as PNG
                    var pngOptions = new PngOptions();
                    raster.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}