using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "sample.png";
        string outputPath = "output.apng";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Apply a median filter with a kernel size of 5 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Ensure the output directory exists (creates it unconditionally)
            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            // Save the filtered image as an APNG file
            rasterImage.Save(outputPath, new ApngOptions());
        }
    }
}