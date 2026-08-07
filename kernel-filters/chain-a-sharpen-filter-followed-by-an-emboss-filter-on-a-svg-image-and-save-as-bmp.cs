using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                // Set up rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Rasterize SVG to a memory stream as PNG
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load rasterized image
                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImg;

                        // Apply sharpen filter
                        raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                        // Apply emboss filter using predefined kernel
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                        // Save as BMP
                        BmpOptions bmpOptions = new BmpOptions();
                        raster.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to enhance the visual detail of a logo stored as SVG for inclusion in a Windows desktop application that only supports BMP assets, they can rasterize, sharpen, emboss, and save it as BMP.
 * 2. When preparing high‑contrast icons for a legacy embedded system that requires BMP files, chaining a sharpen filter followed by an emboss filter on the original SVG ensures the icons remain crisp after rasterization.
 * 3. When generating printable schematics where edge definition is critical, a developer can sharpen and emboss a vector diagram (SVG) before converting it to BMP for use in a reporting tool that only accepts bitmap images.
 * 4. When creating stylized thumbnails for a product catalog that must be displayed on older browsers supporting BMP, applying a sharpen filter then an emboss filter to the SVG provides a distinctive, tactile look.
 * 5. When converting SVG artwork into BMP format for a game engine that does not support vector graphics, chaining these filters in C# adds depth and clarity to the rasterized textures.
 */