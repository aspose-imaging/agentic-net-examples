using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG image
        using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
        {
            // Obtain rasterization options for the SVG
            var rasterOptions = (Aspose.Imaging.ImageOptions.VectorRasterizationOptions)svgImage.GetDefaultOptions(
                new object[] { Aspose.Imaging.Color.White, svgImage.Width, svgImage.Height });

            // Prepare PNG options with vector rasterization
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                svgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized PNG as a RasterImage
                using (Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(memoryStream))
                {
                    // Apply a median filter as an example of processing
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions();
                    rasterImage.Filter(rasterImage.Bounds, filterOptions);

                    // Save the processed image as PNG
                    var finalPngOptions = new PngOptions();
                    rasterImage.Save(outputPath, finalPngOptions);
                }
            }
        }
    }
}