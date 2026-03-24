using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output/output.png";

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
            // Cast to RasterImage for processing
            RasterImage raster = (RasterImage)image;

            // Resize the image
            raster.Resize(200, 200, ResizeType.NearestNeighbourResample);

            // Apply a median filter
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Save processed image to a memory stream (PNG format)
            using (MemoryStream ms = new MemoryStream())
            {
                raster.Save(ms, new PngOptions());
                Console.WriteLine($"Image saved to memory stream, length: {ms.Length}");
            }

            // Also save the processed image to a file
            raster.Save(outputPath, new PngOptions());
        }
    }
}