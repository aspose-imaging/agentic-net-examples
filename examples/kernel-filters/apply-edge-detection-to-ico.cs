using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.ico";
        string outputPath = "output.ico";

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Edge detection filter is not available in Aspose.Imaging.
            // Throw an exception to indicate the unsupported operation.
            throw new NotSupportedException("Edge detection filter is not supported by Aspose.Imaging.");

            // Example of applying a supported filter (commented out):
            // RasterImage raster = (RasterImage)image;
            // raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
            // raster.Save(outputPath);
        }
    }
}