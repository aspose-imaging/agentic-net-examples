using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svgz";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVGZ image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            // Save the vector image to a memory stream as PNG (rasterized)
            using (var ms = new MemoryStream())
            {
                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                vectorImage.Save(ms, pngSaveOptions);
                ms.Position = 0;

                // Load the rasterized PNG as a RasterImage
                using (Image rasterImageWrapper = Image.Load(ms))
                {
                    var rasterImage = (RasterImage)rasterImageWrapper;

                    // Apply emboss filter using convolution kernel
                    var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                    rasterImage.Filter(rasterImage.Bounds, embossOptions);

                    // Save the processed image to the output path
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}