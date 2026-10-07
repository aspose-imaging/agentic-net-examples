// HOW-TO: Apply Horizontal Motion Blur to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\image.tif";
        string outputPath = "output\\result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0, 0, 0, 0, 0 },
                    { 0.2, 0.2, 0.2, 0.2, 0.2 },
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to simulate camera motion by blurring a scanned TIFF and deliver the result as a PNG for web display.
 * 2. When converting high‑resolution TIFF scans of documents into lightweight PNGs while adding a horizontal blur to hide sensitive details.
 * 3. When preprocessing satellite or aerial TIFF imagery with a horizontal motion effect before embedding it in a PNG map overlay.
 * 4. When creating stylized product photos from TIFF assets by applying a horizontal blur and exporting to PNG for e‑commerce platforms.
 * 5. When automating a batch job that reads TIFF files, applies a motion‑blur filter, and saves the output as PNG for downstream image‑analysis pipelines.
 */
