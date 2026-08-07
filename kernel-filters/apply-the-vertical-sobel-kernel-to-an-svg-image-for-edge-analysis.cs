using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

            using (Image image = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var rasterOptions = new SvgRasterizationOptions { PageSize = image.Size };
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImg;

                        double[,] kernel = new double[,]
                        {
                            { -1, 0, 1 },
                            { -2, 0, 2 },
                            { -1, 0, 1 }
                        };
                        var convOptions = new ConvolutionFilterOptions(kernel);
                        rasterImage.Filter(rasterImage.Bounds, convOptions);

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
 * 1. When a developer wants to detect vertical edges in an SVG logo and export the result as a PNG for quality inspection.
 * 2. When an automated pipeline needs to convert vector graphics to raster format and apply a Sobel filter to highlight structural outlines before OCR.
 * 3. When a web service generates thumbnails of user‑uploaded SVG diagrams and uses vertical Sobel convolution to emphasize borders for better visual contrast.
 * 4. When a desktop application analyzes engineering schematics stored as SVG files to identify vertical lines and save the processed image for reporting.
 * 5. When a machine‑learning preprocessing step requires edge detection on vector icons, converting them to raster PNGs and applying the vertical Sobel kernel to create feature maps.
 */