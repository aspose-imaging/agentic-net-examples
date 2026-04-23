using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

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

        // Load the SVG image
        using (Image svgImage = Image.Load(inputPath))
        {
            // Rasterize SVG to a memory stream as PNG
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Set up rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                // Configure PNG save options with vector rasterization
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save rasterized image to memory stream
                svgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load rasterized image as RasterImage
                using (Image rasterImageContainer = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    // Apply deconvolution filter (Gauss-Wiener) to restore details
                    rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));

                    // Save the processed image as PNG
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}