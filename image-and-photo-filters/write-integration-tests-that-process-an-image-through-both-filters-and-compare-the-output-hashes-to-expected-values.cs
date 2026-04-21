using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.png";
            string outputMedianPath = "output_median.png";
            string outputSharpenPath = "output_sharpen.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputMedianPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputSharpenPath));

            // Apply Median filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
                raster.Save(outputMedianPath, new PngOptions());
            }

            // Apply Sharpen filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                raster.Save(outputSharpenPath, new PngOptions());
            }

            // Simple checksum verification
            int expectedMedianChecksum = 12345678; // replace with actual expected checksum
            int expectedSharpenChecksum = 87654321; // replace with actual expected checksum

            int medianChecksum = File.ReadAllBytes(outputMedianPath).Sum(b => (int)b);
            int sharpenChecksum = File.ReadAllBytes(outputSharpenPath).Sum(b => (int)b);

            Console.WriteLine($"Median filter checksum match: {medianChecksum == expectedMedianChecksum}");
            Console.WriteLine($"Sharpen filter checksum match: {sharpenChecksum == expectedSharpenChecksum}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}