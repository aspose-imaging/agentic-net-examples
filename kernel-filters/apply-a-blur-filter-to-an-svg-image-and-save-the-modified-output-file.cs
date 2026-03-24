using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output\\blurred.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage
            SvgImage svgImage = (SvgImage)image;

            // Set up rasterization options for PNG output
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to a memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                svgImage.Save(ms, pngOptions);
                ms.Position = 0;

                // Load the rasterized image
                using (Image rasterImageContainer = Image.Load(ms))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    // Apply Gaussian blur filter
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred image as PNG
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}