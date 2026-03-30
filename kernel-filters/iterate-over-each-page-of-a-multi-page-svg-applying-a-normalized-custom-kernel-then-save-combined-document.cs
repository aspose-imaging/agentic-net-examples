using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = "input.svg";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            List<Aspose.Imaging.RasterImage> processedPages = new List<Aspose.Imaging.RasterImage>();

            if (image is Aspose.Imaging.IMultipageImage multipage && multipage.PageCount > 0)
            {
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    using (var ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };
                        image.Save(ms, pngOptions);
                        ms.Position = 0;

                        Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms);

                        double[,] kernel = new double[,]
                        {
                            { 0, -1, 0 },
                            { -1, 5, -1 },
                            { 0, -1, 0 }
                        };
                        double sum = 0;
                        foreach (double v in kernel) sum += v;
                        if (sum != 0)
                        {
                            for (int r = 0; r < kernel.GetLength(0); r++)
                                for (int c = 0; c < kernel.GetLength(1); c++)
                                    kernel[r, c] /= sum;
                        }

                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);
                        processedPages.Add(raster);
                    }
                }
            }
            else
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                using (var ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms);

                    double[,] kernel = new double[,]
                    {
                        { 0, -1, 0 },
                        { -1, 5, -1 },
                        { 0, -1, 0 }
                    };
                    double sum = 0;
                    foreach (double v in kernel) sum += v;
                    if (sum != 0)
                    {
                        for (int r = 0; r < kernel.GetLength(0); r++)
                            for (int c = 0; c < kernel.GetLength(1); c++)
                                kernel[r, c] /= sum;
                    }

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);
                    processedPages.Add(raster);
                }
            }

            Aspose.Imaging.Image[] imagesArray = processedPages.ConvertAll(i => (Aspose.Imaging.Image)i).ToArray();
            using (Aspose.Imaging.Image result = Aspose.Imaging.Image.Create(imagesArray, true))
            {
                var pdfOptions = new PdfOptions();
                result.Save(outputPath, pdfOptions);
            }

            foreach (var raster in processedPages)
                raster.Dispose();
        }
    }
}