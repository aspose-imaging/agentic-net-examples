// HOW-TO: Create 11x11 Gaussian Blur Kernel and Apply to SVG in C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, new PngOptions());
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        int size = 11;
                        double sigma = 4.5;
                        double[,] kernel = new double[size, size];
                        double sum = 0.0;
                        int half = size / 2;
                        double twoSigmaSq = 2 * sigma * sigma;

                        for (int y = -half; y <= half; y++)
                        {
                            for (int x = -half; x <= half; x++)
                            {
                                double exponent = -(x * x + y * y) / twoSigmaSq;
                                double value = Math.Exp(exponent);
                                kernel[y + half, x + half] = value;
                                sum += value;
                            }
                        }

                        for (int y = 0; y < size; y++)
                        {
                            for (int x = 0; x < size; x++)
                            {
                                kernel[y, x] /= sum;
                            }
                        }

                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);
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
 * 1. When you need to soften vector graphics before converting them to a raster PNG for web thumbnails.
 * 2. When you want to programmatically apply a custom Gaussian blur with a specific kernel size and sigma to an SVG image in a .NET application.
 * 3. When you must generate blurred background images from SVG logos for UI overlays or marketing materials.
 * 4. When you need to preprocess SVG artwork with a Gaussian filter to reduce visual noise before further image analysis.
 * 5. When you are building an automated pipeline that converts SVG files to PNG with a consistent blur effect for a uniform visual style.
 */
