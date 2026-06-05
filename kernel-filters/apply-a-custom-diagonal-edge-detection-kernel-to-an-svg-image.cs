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

            using (Image vectorImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = vectorImage.Size }
                    };
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImage = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImage;

                        // Custom diagonal edge‑detection kernel
                        double[,] kernel = new double[,]
                        {
                            { -1, -1, 0 },
                            { -1,  0, 1 },
                            {  0,  1, 1 }
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
 * 1. When a developer needs to convert an SVG diagram to a PNG thumbnail while highlighting diagonal edges for better visual inspection in a web dashboard.
 * 2. When an image‑processing pipeline must apply a custom diagonal edge‑detection filter to vector graphics before feeding them into a machine‑learning model that expects raster input.
 * 3. When a reporting tool generates SVG charts and the developer wants to emphasize trend lines by rasterizing the SVG and applying a convolution kernel to accentuate diagonal edges in the final PNG export.
 * 4. When a mobile app downloads SVG icons, the backend uses C# and Aspose.Imaging to rasterize them and apply a diagonal edge filter so the icons appear sharper on low‑resolution screens.
 * 5. When a quality‑control system needs to detect misaligned components in SVG schematics, the code rasterizes the SVG and runs a custom diagonal edge‑detection filter to expose alignment errors in a PNG snapshot.
 */