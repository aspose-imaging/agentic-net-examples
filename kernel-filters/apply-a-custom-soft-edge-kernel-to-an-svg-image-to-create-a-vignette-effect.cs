using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

public class Program
{
    public static void Main(string[] args)
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

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        var raster = (RasterImage)rasterImg;

                        double[,] kernel = new double[,]
                        {
                            { 0, 0, 1, 0, 0 },
                            { 0, 2, 2, 2, 0 },
                            { 1, 2, 4, 2, 1 },
                            { 0, 2, 2, 2, 0 },
                            { 0, 0, 1, 0, 0 }
                        };

                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

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
 * 1. When a developer needs to add a vignette effect to an SVG logo before embedding it in a web page, they can use this code to rasterize the SVG to PNG and apply a custom soft‑edge convolution kernel.
 * 2. When a designer wants to automatically generate thumbnail previews of SVG illustrations with a subtle dark border for a gallery, this C# snippet converts the vector to a raster image and applies the soft‑edge filter.
 * 3. When an e‑commerce platform must display product SVG icons with a consistent fade‑out border across browsers, the code rasterizes the icons to PNG and creates the vignette using a convolution filter.
 * 4. When a reporting tool requires SVG charts to be exported as PNG files with a professional vignette finish for PDF reports, this example shows how to rasterize and filter the images in .NET.
 * 5. When a mobile app backend processes user‑uploaded SVG avatars and needs to add a soft‑edge mask before saving them as PNGs for faster loading, the code demonstrates the necessary rasterization and convolution steps.
 */