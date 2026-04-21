using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
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

        // Load SVG image from file stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        using (SvgImage svgImage = new SvgImage(inputStream))
        {
            // Set up rasterization options for SVG to PNG conversion
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to PNG in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                svgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized PNG as a RasterImage
                using (Image rasterImageContainer = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    // Apply Gaussian blur filter (radius 5, sigma 4.0)
                    rasterImage.Filter(rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred image to the output path
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}