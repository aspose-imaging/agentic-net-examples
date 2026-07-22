using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        var blurKernel = ConvolutionFilter.GetBlurBox(3);
                        var blurOptions = new ConvolutionFilterOptions(blurKernel);
                        rasterImage.Filter(rasterImage.Bounds, blurOptions);

                        rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When generating thumbnail previews of vector icons for a web gallery, a developer can use this C# code to rasterize the SVG, apply a 3×3 blur box filter, and save the result as a PNG to reduce aliasing.
 * 2. When converting user‑uploaded SVG diagrams to PNG for email attachments, the code enables applying a subtle blur via Aspose.Imaging convolution to smooth edges before saving.
 * 3. When preparing SVG logos for print layouts that require a soft blur effect, a developer can rasterize the SVG, apply the predefined blur box, and output a PNG with the desired visual style.
 * 4. When building a C# batch‑processing tool that rasterizes multiple SVG assets to PNG, this code adds a uniform 3×3 blur to each image, creating consistent background placeholders.
 * 5. When implementing an automated CI pipeline that validates SVG assets, the code renders each SVG to PNG, applies a blur filter to highlight rendering artifacts, and saves the processed images for review.
 */