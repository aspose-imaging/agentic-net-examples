// HOW-TO: Apply Custom Convolution Filter to Each Page of a Multipage SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                if (image is Aspose.Imaging.IMultipageImage multipageImage)
                {
                    int pageCount = multipageImage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        using (Aspose.Imaging.Image pageImage = multipageImage.Pages[i])
                        {
                            var pngOptions = new PngOptions();
                            var rasterOptions = new SvgRasterizationOptions();
                            rasterOptions.PageWidth = pageImage.Width;
                            rasterOptions.PageHeight = pageImage.Height;
                            rasterOptions.BackgroundColor = Aspose.Imaging.Color.White;
                            pngOptions.VectorRasterizationOptions = rasterOptions;

                            string outputPath = Path.Combine("output", $"page_{i}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            pageImage.Save(outputPath, pngOptions);

                            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(outputPath))
                            {
                                double[,] kernel = new double[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
                                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                                raster.Filter(raster.Bounds, convOptions);
                                raster.Save(outputPath);
                            }
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image does not support multiple pages.");
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
 * 1. When you need to convert every layer of a multi‑page SVG diagram into high‑resolution PNGs and enhance each image with a custom sharpening kernel.
 * 2. When generating thumbnails for each page of a vector brochure and applying a specific edge‑enhancement filter before publishing.
 * 3. When processing architectural SVG plans page by page, rasterizing them to PNG and using a convolution matrix to improve line clarity for downstream analysis.
 * 4. When automating batch preparation of SVG icons for a mobile app, converting each icon page to PNG and applying a custom filter to match the app’s visual style.
 * 5. When creating print‑ready assets from a multi‑page SVG file and need to apply a user‑defined convolution filter to each page to meet quality standards.
 */
