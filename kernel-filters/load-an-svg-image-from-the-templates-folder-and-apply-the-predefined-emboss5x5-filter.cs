using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "templates/input.svg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                // Set up rasterization options for SVG to PNG conversion
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Rasterize SVG into a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImageContainer = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        // Apply Emboss5x5 convolution filter
                        rasterImage.Filter(rasterImage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));

                        // Save the filtered image as PNG
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
 * 1. When a web application needs to generate stylized PNG thumbnails from SVG icons with an embossed effect for UI hover states.
 * 2. When an e‑commerce platform wants to convert product vector illustrations into high‑resolution PNG images and add depth using the Emboss5x5 filter before displaying them on product pages.
 * 3. When a reporting tool automatically creates printable PNG charts from SVG diagrams and applies an emboss filter to enhance visual contrast in PDF exports.
 * 4. When a mobile game developer pre‑processes SVG assets into PNG textures with an emboss effect to achieve a 3‑D look without increasing runtime processing.
 * 5. When a document automation system batch‑processes SVG logos, rasterizes them to PNG, and applies the Emboss5x5 convolution to meet branding guidelines for embossed watermarking.
 */