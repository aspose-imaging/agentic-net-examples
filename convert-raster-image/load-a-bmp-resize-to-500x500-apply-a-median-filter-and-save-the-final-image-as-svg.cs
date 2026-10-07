// HOW-TO: Resize BMP to 500x500, Apply Median Filter, Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                image.Resize(500, 500, ResizeType.NearestNeighbourResample);

                var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                image.Filter(image.Bounds, medianOptions);

                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to convert a high‑resolution BMP photograph into a smaller 500 × 500 SVG graphic while reducing noise for web display.
 * 2. When preparing icons from legacy BMP assets for responsive UI designs, you can resize them and apply a median filter before exporting to scalable SVG.
 * 3. When cleaning up scanned BMP documents, applying a median filter and saving as SVG enables lossless vector rendering for printing.
 * 4. When automating batch processing of BMP images to generate lightweight SVG thumbnails with noise reduction in a C# backend service.
 * 5. When integrating Aspose.Imaging into a .NET application to transform raster BMP files into vector SVG files with consistent dimensions and filtered quality.
 */
