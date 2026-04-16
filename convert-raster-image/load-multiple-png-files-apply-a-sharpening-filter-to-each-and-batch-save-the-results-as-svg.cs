using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input PNG files
        string[] inputFiles = new[]
        {
            @"c:\temp\image1.png",
            @"c:\temp\image2.png",
            @"c:\temp\image3.png"
        };

        // Hard‑coded output folder for SVG files
        string outputFolder = @"c:\output\";

        foreach (string inputPath in inputFiles)
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output SVG path (same file name, .svg extension)
            string outputPath = Path.Combine(outputFolder,
                Path.GetFileNameWithoutExtension(inputPath) + ".svg");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image, apply sharpening, and save as SVG
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage raster = (RasterImage)image;

                // Apply a sharpen filter (kernel size 5, sigma 4.0)
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image as SVG using default options
                raster.Save(outputPath, new SvgOptions());
            }
        }
    }
}