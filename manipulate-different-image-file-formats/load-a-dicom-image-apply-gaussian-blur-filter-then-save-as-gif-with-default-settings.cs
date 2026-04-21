using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as GIF with default options
            image.Save(outputPath, new GifOptions());
        }
    }
}