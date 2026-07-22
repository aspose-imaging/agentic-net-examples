using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output\\vignette.png";

        try
        {
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
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImg;

                        double[,] kernel = new double[,]
                        {
                            { 0.5, 0.75, 0.5 },
                            { 0.75, 1.0, 0.75 },
                            { 0.5, 0.75, 0.5 }
                        };

                        var convOptions = new ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, convOptions);

                        raster.Save(outputPath, new PngOptions());
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
 * 1. When a web developer wants to generate thumbnail PNGs from SVG icons with a subtle vignette to improve visual focus in a product catalog.
 * 2. When a desktop application needs to batch‑process SVG logos into high‑resolution PNG assets with a soft‑edge kernel to create a professional fade‑out border for printed brochures.
 * 3. When an e‑learning platform automatically converts SVG diagrams to PNG images with a vignette effect to reduce glare and guide the learner’s attention to the central content.
 * 4. When a mobile game engine imports vector assets and applies a custom convolution filter to add a soft vignette before saving them as PNG textures for better in‑game aesthetics.
 * 5. When a marketing automation script rasterizes SVG banners, applies a soft‑edge kernel via Aspose.Imaging’s ConvolutionFilterOptions, and saves the result as PNG to ensure consistent vignette styling across email campaigns.
 */