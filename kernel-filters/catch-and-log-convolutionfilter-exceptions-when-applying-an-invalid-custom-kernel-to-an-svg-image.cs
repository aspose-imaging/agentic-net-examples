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
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;
                        var outPngOptions = new PngOptions();
                        rasterImage.Save(outputPath, outPngOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application converts an SVG diagram to a PNG thumbnail and applies a custom convolution filter, catching ConvolutionFilter exceptions ensures that an invalid kernel does not crash the service and the error is logged for troubleshooting.
 * 2. When a web API receives user‑uploaded SVG graphics and allows clients to specify image sharpening kernels, handling ConvolutionFilter exceptions lets the API return a friendly error response while recording the faulty kernel details.
 * 3. When an automated batch job processes thousands of SVG icons with edge‑detection filters, logging ConvolutionFilter exceptions helps identify and skip files that contain unsupported kernel dimensions without stopping the entire batch.
 * 4. When a desktop tool lets designers preview real‑time filter effects on vector artwork, catching and logging ConvolutionFilter exceptions prevents the preview window from freezing when the designer enters an out‑of‑range kernel value.
 * 5. When a CI/CD pipeline validates image assets by rasterizing SVGs and applying custom blur kernels, capturing ConvolutionFilter exceptions allows the build to fail gracefully and provides a clear log entry indicating the problematic kernel configuration.
 */