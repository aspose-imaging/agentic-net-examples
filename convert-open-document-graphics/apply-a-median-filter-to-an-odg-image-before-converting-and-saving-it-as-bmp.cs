using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string intermediatePath = @"C:\Images\temp.bmp";
            string outputPath = @"C:\Images\sample_filtered.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Save it as a temporary BMP to obtain a raster image
                odgImage.Save(intermediatePath, new BmpOptions());
            }

            // Load the temporary BMP as a raster image
            using (Image bmpImage = Image.Load(intermediatePath))
            {
                var rasterImage = (RasterImage)bmpImage;

                // Apply a median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the filtered image as BMP
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}