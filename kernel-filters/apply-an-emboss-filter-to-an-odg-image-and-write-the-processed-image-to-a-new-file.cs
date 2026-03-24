using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG vector image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Set up rasterization options for converting vector to raster (PNG)
            var rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = vectorImage.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize to an in‑memory PNG
            using (var memoryStream = new MemoryStream())
            {
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (Image rasterImageContainer = Image.Load(memoryStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    // Apply emboss filter using convolution kernel
                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save the processed image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}