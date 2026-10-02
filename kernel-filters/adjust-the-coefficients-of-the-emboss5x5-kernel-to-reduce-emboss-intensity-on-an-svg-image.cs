// HOW-TO: Reduce Emboss Filter Intensity on SVG When Converting to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(memoryStream))
                    {
                        double[,] originalKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5;
                        int rows = originalKernel.GetLength(0);
                        int cols = originalKernel.GetLength(1);
                        double[,] adjustedKernel = new double[rows, cols];
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                adjustedKernel[i, j] = originalKernel[i, j] * 0.5;
                            }
                        }

                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(adjustedKernel);
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        var outOptions = new PngOptions();
                        rasterImage.Save(outputPath, outOptions);
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
 * 1. When you need to convert an SVG logo to a PNG thumbnail and want a subtle emboss effect for a web UI using Aspose.Imaging in C#.
 * 2. When rasterizing vector graphics for print and the default emboss is too harsh, so you scale down the kernel to achieve a softer shadow.
 * 3. When generating icons from SVG files for a mobile app and the built‑in emboss filter creates overly pronounced edges, requiring a reduced intensity.
 * 4. When processing a batch of SVG assets for a game and you must tone down the emboss to match the game's art style without losing depth.
 * 5. When creating PDF reports that embed PNG versions of SVG diagrams and you need a gentle emboss to add visual depth without distracting the reader.
 */
