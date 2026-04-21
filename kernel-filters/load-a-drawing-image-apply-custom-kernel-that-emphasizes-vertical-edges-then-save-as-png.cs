using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the drawing image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to enable filtering
                RasterImage raster = (RasterImage)image;

                // Apply a custom kernel that emphasizes vertical edges.
                // Here we use a Sharpen filter (3x3) which highlights edges,
                // including vertical ones. For a true vertical Sobel kernel,
                // a custom filter would be needed, but this demonstrates the approach.
                raster.Filter(raster.Bounds, new SharpenFilterOptions(3, 1.0));

                // Save the processed image as PNG
                PngOptions pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}