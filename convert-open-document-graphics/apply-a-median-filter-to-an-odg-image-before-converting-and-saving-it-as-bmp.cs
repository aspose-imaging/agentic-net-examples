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
        // Hard‑coded input and output file paths
        string inputPath = "sample.odg";
        string outputPath = "sample_filtered.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to enable pixel‑level operations
            RasterImage rasterImage = (RasterImage)image;

            // Apply a median filter with a size of 5 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Prepare BMP save options (default options are sufficient here)
            BmpOptions bmpOptions = new BmpOptions();

            // Save the filtered image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}