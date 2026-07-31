using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\vector.svg";
        string outputPath = @"C:\temp\output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = vectorImage.Width,
                    PageHeight = vectorImage.Height
                };

                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                    vectorImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        var raster = rasterImage as RasterImage;
                        if (raster != null)
                        {
                            var embossKernel = ConvolutionFilter.Emboss3x3;
                            var embossOptions = new ConvolutionFilterOptions(embossKernel);
                            raster.Filter(raster.Bounds, embossOptions);

                            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                            {
                                ResolutionSettings = new ResolutionSetting(300, 300)
                            };

                            raster.Save(outputPath, tiffOptions);
                        }
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
 * 1. When a developer needs to convert an SVG logo into a high‑resolution 300 DPI TIFF for print‑ready catalogs while adding a 3×3 emboss effect using Aspose.Imaging for .NET.
 * 2. When a web‑application must generate embossed preview images from user‑uploaded vector drawings and store them as lossless TIFF files for archival purposes.
 * 3. When an engineering tool requires rasterizing technical diagrams from SVG, applying a custom convolution emboss filter, and exporting the result as a TIFF to meet ISO imaging standards.
 * 4. When a desktop utility has to batch‑process vector artwork, add depth with an emboss filter, and output high‑quality TIFFs for downstream GIS or CAD software.
 * 5. When a reporting system needs to embed stylized vector graphics into PDF reports by first creating an embossed TIFF at 300 dpi using C# and Aspose.Imaging’s rasterization and filter APIs.
 */