// HOW-TO: Apply Custom Edge Detection Kernel to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";
        string tempPngPath = "temp.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");

        try
        {
            using (Aspose.Imaging.Image svgImg = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)svgImg;
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };
                svgImg.Save(tempPngPath, pngOptions);
            }

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempPngPath))
            {
                double[,] customKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                raster.Filter(new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height), filterOptions);
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to highlight edges in a vector graphic by converting an SVG to a raster PNG with a custom convolution filter.
 * 2. When you want to preprocess SVG logos for computer‑vision models by applying a diagonal edge‑detection kernel before analysis.
 * 3. When you must generate high‑contrast thumbnails of SVG diagrams for web previews using a custom filter in C#.
 * 4. When you are building a batch pipeline that rasterizes SVG assets and applies a user‑defined kernel to create stylized PNG assets.
 * 5. When you need to detect and emphasize structural lines in technical drawings stored as SVG files for printing or reporting.
 */
