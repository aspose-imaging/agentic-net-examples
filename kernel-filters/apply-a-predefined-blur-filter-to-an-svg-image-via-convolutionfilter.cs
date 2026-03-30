using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the SVG image
        using (Image svgImage = Image.Load(inputPath))
        {
            // Rasterize SVG to a PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions();
                svgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image for filtering
                using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Create a predefined blur filter using a 3x3 box blur kernel
                    var blurKernel = ConvolutionFilter.GetBlurBox(3);
                    var blurOptions = new ConvolutionFilterOptions(blurKernel, factor: 1.0, bias: 0);

                    // Apply the blur filter to the entire image
                    rasterImage.Filter(rasterImage.Bounds, blurOptions);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the filtered image
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}