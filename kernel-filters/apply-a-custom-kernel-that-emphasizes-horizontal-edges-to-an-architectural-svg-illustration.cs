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
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream inputStream = File.OpenRead(inputPath))
            using (SvgImage svgImage = new SvgImage(inputStream))
            {
                // Rasterize SVG to PNG in memory
                var pngOptions = new PngOptions();
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                pngOptions.VectorRasterizationOptions = vectorOptions;

                using (MemoryStream rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    using (Image rasterImg = Image.Load(rasterStream))
                    {
                        var raster = (RasterImage)rasterImg;

                        // Custom kernel for horizontal edge detection (Sobel)
                        double[,] kernel = new double[,]
                        {
                            { -1, -2, -1 },
                            {  0,  0,  0 },
                            {  1,  2,  1 }
                        };

                        var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, convOptions);

                        // Save the filtered raster image
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
 * 1. When a developer needs to generate a printable blueprint preview that highlights horizontal structural lines in an architectural SVG by rasterizing it to PNG and applying a Sobel horizontal edge‑detection kernel.
 * 2. When a web application must create a high‑contrast thumbnail of a floor‑plan SVG where only the horizontal walls are emphasized, using Aspose.Imaging’s rasterization and convolution filter in C#.
 * 3. When an engineering report requires a PNG image of a building elevation with enhanced horizontal edges to improve visual analysis, and the code converts the SVG and applies a custom kernel for edge detection.
 * 4. When a GIS system needs to overlay an SVG map of a city’s street grid onto raster data and wants to accentuate the east‑west roads by filtering the rasterized image with a horizontal Sobel kernel.
 * 5. When a mobile app automatically extracts horizontal beam outlines from an SVG structural diagram by converting it to PNG and running a convolution filter that emphasizes horizontal edges for further processing.
 */