// HOW-TO: Convert Multi‑Page SVG to Combined TIFF with Custom Kernel in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\multipage.svg";
            string outputPath = @"C:\temp\combined.tiff";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG (could be multipage)
            using (Image svgImage = Image.Load(inputPath))
            {
                IMultipageImage multipage = svgImage as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                List<RasterImage> processedPages = new List<RasterImage>();

                for (int i = 0; i < pageCount; i++)
                {
                    Image pageImage = multipage != null ? multipage.Pages[i] : svgImage;

                    // Rasterization options for SVG page
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = pageImage.Size,
                        BackgroundColor = Color.White
                    };

                    // Temporary PNG path
                    string tempPng = Path.Combine(Path.GetTempPath(), $"page_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(tempPng));

                    // Save rasterized PNG
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    pageImage.Save(tempPng, pngOptions);

                    // Load rasterized PNG and apply convolution filter
                    RasterImage raster = (RasterImage)Image.Load(tempPng);
                    double[,] kernel = new double[,]
                    {
                        { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                        { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                        { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                    };
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                    // Keep processed raster for later merging
                    processedPages.Add(raster);

                    // Delete temporary PNG
                    try { File.Delete(tempPng); } catch { }
                }

                if (processedPages.Count == 0)
                {
                    Console.Error.WriteLine("No pages were processed.");
                    return;
                }

                // Prepare TIFF output options
                Source tiffSource = new FileCreateSource(outputPath, false);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = tiffSource
                };

                // Create TIFF canvas and add pages
                using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, processedPages[0].Width, processedPages[0].Height))
                {
                    // Write first page pixels
                    ((RasterImage)tiff).SaveArgb32Pixels(
                        new Rectangle(0, 0, processedPages[0].Width, processedPages[0].Height),
                        processedPages[0].LoadArgb32Pixels(processedPages[0].Bounds));

                    // Add remaining pages
                    for (int i = 1; i < processedPages.Count; i++)
                    {
                        tiff.AddPage(processedPages[i]);
                    }

                    // Save the multipage TIFF
                    tiff.Save();
                }

                // Dispose processed raster pages
                foreach (var page in processedPages)
                {
                    page.Dispose();
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
 * 1. When you need to turn a multi‑page vector illustration into a single multipage TIFF for printing or archival.
 * 2. When you must rasterize each SVG page to a high‑resolution bitmap before applying a custom image filter.
 * 3. When you want to automate the conversion of SVG assets into a format supported by legacy document management systems.
 * 4. When you need to generate a combined TIFF from separate SVG pages for batch processing in a .NET application.
 * 5. When you require a temporary PNG intermediate to apply normalization kernels before merging pages into a final TIFF file.
 */
