// HOW-TO: Apply Vertical Sobel Edge Detection to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string tempPngPath = "temp.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load SVG and rasterize to PNG
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;
                var pngOptions = new PngOptions();
                using (FileStream fs = new FileStream(tempPngPath, FileMode.Create))
                {
                    svgImage.Save(fs, pngOptions);
                }
            }

            // Load rasterized image and apply vertical Sobel kernel
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                double[,] sobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelKernel);
                raster.Filter(raster.Bounds, filterOptions);

                var outOptions = new PngOptions();
                raster.Save(outputPath, outOptions);
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
 * 1. When you need to extract vertical edges from a vector logo (SVG) to create a high‑contrast PNG for printing or UI overlays.
 * 2. When you want to preprocess SVG diagrams for computer‑vision algorithms by converting them to raster format and applying a Sobel filter.
 * 3. When generating thumbnail previews that highlight structural outlines of SVG icons for a web gallery.
 * 4. When performing quality‑control checks on SVG assets by detecting missing strokes or broken paths through edge analysis.
 * 5. When integrating Aspose.Imaging into a C# batch job that converts multiple SVG files to edge‑detected PNGs for machine‑learning training data.
 */
