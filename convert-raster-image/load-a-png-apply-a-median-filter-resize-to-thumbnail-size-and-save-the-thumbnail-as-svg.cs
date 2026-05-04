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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\thumbnail.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access raster‑specific operations
                RasterImage raster = (RasterImage)image;

                // Apply a median filter with a kernel size of 5
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Resize to thumbnail dimensions (e.g., 100x100 pixels)
                raster.Resize(100, 100);

                // Save the processed image as SVG
                raster.Save(outputPath, new SvgOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}