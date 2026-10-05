// HOW-TO: Apply Soft Edge Vignette to SVG and Export as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
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

            using (MemoryStream ms = new MemoryStream())
            {
                var pngOptions = new PngOptions();
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = 800,
                    PageHeight = 600
                };
                pngOptions.VectorRasterizationOptions = rasterizationOptions;

                using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
                {
                    svgImage.Save(ms, pngOptions);
                }

                ms.Position = 0;

                using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(ms))
                {
                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)img;
                    if (!raster.IsCached) raster.CacheData();

                    double[,] kernel = new double[5, 5]
                    {
                        { 0.0, 0.0, 0.1, 0.0, 0.0 },
                        { 0.0, 0.2, 0.5, 0.2, 0.0 },
                        { 0.1, 0.5, 1.0, 0.5, 0.1 },
                        { 0.0, 0.2, 0.5, 0.2, 0.0 },
                        { 0.0, 0.0, 0.1, 0.0, 0.0 }
                    };
                    var convOptions = new ConvolutionFilterOptions(kernel);
                    raster.Filter(new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height), convOptions);

                    var outOptions = new PngOptions();
                    raster.Save(outputPath, outOptions);
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
 * 1. When you need to add a subtle vignette border to an SVG logo before embedding it in a web page as a PNG.
 * 2. When you want to convert vector graphics to raster images with a custom soft‑edge filter for print‑ready PDFs.
 * 3. When you need to programmatically create a faded edge effect on icons for a mobile app UI using C#.
 * 4. When you must preprocess SVG diagrams with a vignette to improve visual focus in a reporting dashboard.
 * 5. When you are automating batch processing of SVG assets to generate PNG thumbnails with a soft‑edge look.
 */
