using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
        {
            // Set up rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // PNG save options with rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to a PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                svgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(memoryStream))
                {
                    var raster = (Aspose.Imaging.RasterImage)rasterImg;

                    // Apply motion blur (motion wiener) filter
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the processed image
                    raster.Save(outputPath);
                }
            }
        }
    }
}