using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Set up PNG save options with rasterization
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream
                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load rasterized image
                    using (Image rasterImg = Image.Load(ms))
                    {
                        var raster = (RasterImage)rasterImg;

                        // Retrieve original Emboss5x5 kernel
                        double[,] originalKernel = ConvolutionFilter.Emboss5x5;

                        // Reduce intensity by scaling coefficients (e.g., 50%)
                        int rows = originalKernel.GetLength(0);
                        int cols = originalKernel.GetLength(1);
                        double[,] modifiedKernel = new double[rows, cols];
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                modifiedKernel[i, j] = originalKernel[i, j] * 0.5;
                            }
                        }

                        // Apply convolution filter with modified kernel
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(modifiedKernel));

                        // Save the filtered image as PNG
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
 * 1. When a developer needs to generate a lighter embossed effect for SVG icons that are rasterized to PNG for a web UI, they can use this code to scale the Emboss5x5 kernel coefficients and reduce intensity.
 * 2. When creating printable PDFs from SVG diagrams where a subtle emboss is required to enhance depth without overwhelming the design, the code lets the developer adjust the kernel before rasterizing.
 * 3. When building an automated image‑processing pipeline that converts user‑uploaded SVG logos to PNG thumbnails with a gentle emboss for branding consistency, this example shows how to modify the convolution filter in C#.
 * 4. When optimizing SVG assets for mobile apps and want to apply a low‑intensity emboss to improve visual appeal while keeping file size low, the code demonstrates scaling the Emboss5x5 coefficients during rasterization.
 * 5. When integrating Aspose.Imaging into a desktop application that previews SVG artwork with a soft emboss effect, developers can use this snippet to fine‑tune the kernel values to match the desired visual style.
 */