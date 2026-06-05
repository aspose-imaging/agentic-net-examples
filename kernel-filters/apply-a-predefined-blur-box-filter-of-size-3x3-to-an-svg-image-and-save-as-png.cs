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
            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                var rasterOptions = new SvgRasterizationOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                    {
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(3));

                        raster.Filter(raster.Bounds, filterOptions);
                        raster.Save(outputPath);
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
 * 1. When a web application needs to generate a softened thumbnail of a vector logo stored as SVG for faster page loads, a developer can rasterize the SVG to PNG and apply a 3x3 blur box filter using Aspose.Imaging in C#.
 * 2. When creating print‑ready assets that require a subtle background blur to reduce visual noise in SVG illustrations before converting them to high‑resolution PNGs, this code provides an automated C# solution.
 * 3. When a desktop tool must preprocess user‑uploaded SVG icons by adding a light blur effect and exporting them as PNG sprites for UI themes, the Aspose.Imaging filter pipeline can be employed.
 * 4. When a reporting system needs to embed blurred versions of SVG charts into PDF documents as PNG images to protect sensitive data details, developers can use this C# routine.
 * 5. When an e‑learning platform wants to generate blurred PNG overlays from SVG diagrams for focus‑out effects in tutorials, the code demonstrates the required C# image processing steps.
 */