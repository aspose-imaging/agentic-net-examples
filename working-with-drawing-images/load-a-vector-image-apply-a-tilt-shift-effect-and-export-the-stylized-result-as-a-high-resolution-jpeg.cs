using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image vectorImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = vectorImage.Width,
                        PageHeight = vectorImage.Height
                    }
                };

                using (var memoryStream = new MemoryStream())
                {
                    vectorImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                    {
                        var blurOptions = new GaussianBlurFilterOptions
                        {
                            Radius = 8
                        };
                        rasterImage.Filter(rasterImage.Bounds, blurOptions);

                        var jpegOptions = new JpegOptions
                        {
                            Quality = 95,
                            Source = new FileCreateSource(outputPath, false)
                        };

                        rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert an SVG logo into a high‑resolution JPEG thumbnail with a tilt‑shift blur for a marketing website.
 * 2. When an e‑commerce platform must generate stylized product images from vector illustrations on‑the‑fly using C# and Aspose.Imaging.
 * 3. When a desktop publishing tool requires rasterizing SVG artwork, applying a Gaussian blur tilt‑shift effect, and saving the result as a print‑ready JPEG.
 * 4. When a mobile app backend needs to batch‑process SVG icons into blurred JPEG assets for faster loading on low‑bandwidth devices.
 * 5. When a digital signage system automatically transforms vector graphics into high‑quality JPEG backgrounds with a depth‑of‑field effect using .NET.
 */