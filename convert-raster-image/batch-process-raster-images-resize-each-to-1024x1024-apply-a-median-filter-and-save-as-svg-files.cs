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
            // Hardcoded input files (raster images)
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.png",
                @"C:\Images\sample2.jpg",
                @"C:\Images\sample3.bmp"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same folder, .svg extension)
                string outputPath = Path.ChangeExtension(inputPath, ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 1024x1024
                    image.Resize(1024, 1024);

                    // Apply median filter with size 5
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));
                    }

                    // Prepare SVG save options with rasterization settings
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = new Size(1024, 1024)
                    };
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}