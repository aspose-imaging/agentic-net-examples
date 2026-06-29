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
                    PngOptions pngOptions = new PngOptions();
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                    rasterOptions.PageSize = image.Size;
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                    {
                        double[,] emboss = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5;
                        double scaleFactor = 0.5;
                        int rows = emboss.GetLength(0);
                        int cols = emboss.GetLength(1);
                        double[,] kernel = new double[rows, cols];
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                kernel[i, j] = emboss[i, j] * scaleFactor;
                            }
                        }

                        rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

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
 * 1. When a developer wants to generate a PNG thumbnail from an SVG logo and apply a subtle emboss effect to give the image a slight 3‑D look without overwhelming the design.
 * 2. When a web application needs to render user‑uploaded SVG illustrations as PNGs with reduced emboss intensity for consistent visual styling across browsers.
 * 3. When an e‑learning platform converts SVG diagrams to PNG assets and requires a gentle emboss filter to enhance edge definition while preserving readability.
 * 4. When a reporting tool creates PNG charts from SVG vectors and wants to apply a low‑strength emboss kernel to add depth without distorting the chart data.
 * 5. When a mobile app preprocesses SVG icons into PNG sprites and uses a scaled‑down emboss convolution to improve visual appeal on high‑resolution screens.
 */