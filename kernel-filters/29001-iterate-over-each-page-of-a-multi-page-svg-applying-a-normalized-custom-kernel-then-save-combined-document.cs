using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

            var processedImages = new List<Image>();

            using (Image image = Image.Load(inputPath))
            {
                var multipage = image as IMultipageImage;
                if (multipage != null && multipage.PageCount > 0)
                {
                    foreach (Image page in multipage.Pages)
                    {
                        using (page)
                        {
                            var rasterOptions = new SvgRasterizationOptions
                            {
                                PageWidth = page.Width,
                                PageHeight = page.Height,
                                BackgroundColor = Aspose.Imaging.Color.White
                            };
                            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                            using (var ms = new MemoryStream())
                            {
                                page.Save(ms, pngOptions);
                                ms.Position = 0;
                                RasterImage raster = (RasterImage)Image.Load(ms);
                                double[,] kernel = new double[,]
                                {
                                    { 0, -1, 0 },
                                    { -1, 5, -1 },
                                    { 0, -1, 0 }
                                };
                                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
                                processedImages.Add(raster);
                            }
                        }
                    }
                }
                else
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                    using (var ms = new MemoryStream())
                    {
                        image.Save(ms, pngOptions);
                        ms.Position = 0;
                        RasterImage raster = (RasterImage)Image.Load(ms);
                        double[,] kernel = new double[,]
                        {
                            { 0, -1, 0 },
                            { -1, 5, -1 },
                            { 0, -1, 0 }
                        };
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
                        processedImages.Add(raster);
                    }
                }
            }

            using (Image result = Image.Create(processedImages.ToArray()))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                result.Save(outputPath, tiffOptions);
            }

            foreach (var img in processedImages)
            {
                img.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}