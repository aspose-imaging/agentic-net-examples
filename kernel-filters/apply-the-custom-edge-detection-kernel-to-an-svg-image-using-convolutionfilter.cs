// HOW-TO: Apply Custom Edge Detection Kernel to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;

                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageWidth = width,
                        PageHeight = height,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                    {
                        double[,] customKernel = new double[,]
                        {
                            { -1, -1, -1 },
                            { -1,  8, -1 },
                            { -1, -1, -1 }
                        };

                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        var outOptions = new PngOptions();
                        raster.Save(outputPath, outOptions);
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
 * 1. When you need to highlight edges in an SVG graphic before embedding it in a web page, this code rasterizes the vector and applies an edge‑detection filter.
 * 2. When you want to convert an SVG logo to a high‑contrast PNG for printing, the example shows how to rasterize and enhance the image with a custom convolution kernel.
 * 3. When you must preprocess SVG diagrams for computer‑vision analysis that requires strong outlines, the code applies a Laplacian‑style filter to produce a clear edge map.
 * 4. When building a batch tool that automatically applies custom convolution kernels to multiple SVG files and outputs filtered PNGs, this snippet demonstrates the required steps in C#.
 * 5. When integrating Aspose.Imaging into a C# application to rasterize SVGs and apply bespoke image filters without external libraries, the example provides a complete workflow.
 */
