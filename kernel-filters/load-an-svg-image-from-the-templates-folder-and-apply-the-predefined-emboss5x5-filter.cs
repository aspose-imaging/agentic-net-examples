using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "templates/input.svg";
        string outputPath = "output/filtered.png";

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
            // Set up rasterization options for SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White
            };

            // Set up PNG save options with the rasterization options
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

                    // Apply the predefined Emboss5x5 filter
                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                    // Save the filtered image
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}