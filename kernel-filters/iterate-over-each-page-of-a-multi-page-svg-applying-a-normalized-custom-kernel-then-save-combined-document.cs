// HOW-TO: Apply Normalized Kernel to SVG Pages and Export Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            string outputDir = Path.GetDirectoryName(outputPath);
            string tempDir = Path.Combine(outputDir, "temp_svg_pages");
            Directory.CreateDirectory(tempDir);

            List<RasterImage> frames = new List<RasterImage>();

            using (Image svgImage = Image.Load(inputPath))
            {
                if (svgImage is IMultipageImage multipage)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        string tempPngPath = Path.Combine(tempDir, $"page_{i}.png");

                        using (Image page = multipage.Pages[i])
                        {
                            var pngOptions = new PngOptions
                            {
                                VectorRasterizationOptions = new SvgRasterizationOptions
                                {
                                    PageWidth = page.Width,
                                    PageHeight = page.Height
                                }
                            };
                            page.Save(tempPngPath, pngOptions);
                        }

                        using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                        {
                            double[,] kernel = new double[,]
                            {
                                { 1, 2, 1 },
                                { 2, 4, 2 },
                                { 1, 2, 1 }
                            };
                            double sum = 0;
                            foreach (double v in kernel) sum += v;
                            for (int r = 0; r < kernel.GetLength(0); r++)
                            {
                                for (int c = 0; c < kernel.GetLength(1); c++)
                                {
                                    kernel[r, c] /= sum;
                                }
                            }

                            var convOptions = new ConvolutionFilterOptions(kernel);
                            raster.Filter(raster.Bounds, convOptions);
                            frames.Add(raster);
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded SVG does not support multiple pages.");
                    return;
                }
            }

            if (frames.Count == 0)
            {
                Console.Error.WriteLine("No pages were processed.");
                return;
            }

            Source outSource = new FileCreateSource(outputPath, false);
            var tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb) { Source = outSource };

            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, frames[0].Width, frames[0].Height))
            {
                for (int i = 1; i < frames.Count; i++)
                {
                    tiff.AddPage(frames[i]);
                }
                tiff.Save();
            }

            foreach (var frame in frames)
            {
                frame.Dispose();
            }

            Directory.Delete(tempDir, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to rasterize each page of a multi‑page SVG and combine the results into a single multi‑page TIFF for printing or archival purposes.
 * 2. When you want to apply a normalized custom convolution kernel to every SVG page before exporting to TIFF.
 * 3. When a legacy workflow requires converting vector SVG pages into a paginated raster format that legacy TIFF viewers can read.
 * 4. When processing large SVG files page by page is necessary to keep memory usage low while still producing a combined TIFF document.
 * 5. When you must generate a high‑resolution, searchable TIFF from an SVG that contains multiple artboards or pages using C# and Aspose.Imaging.
 */
