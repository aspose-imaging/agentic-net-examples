using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output\\blurred.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to generate high‑resolution PNG thumbnails from user‑uploaded SVG icons for display on browsers that do not support vector graphics.
 * 2. When an e‑commerce platform must convert product illustration SVG files to PNG format before embedding them in PDF invoices generated with .NET.
 * 3. When a desktop publishing tool requires rasterizing SVG logos to PNG so they can be composited with raster images and later processed with filters such as Gaussian blur without exceeding the 255 pixel‑intensity limit.
 * 4. When an automated build pipeline validates that all SVG assets are correctly rasterized to PNG and saved in the designated output folder, ensuring the file system structure exists beforehand.
 * 5. When a reporting service reads SVG charts, rasterizes them to PNG, and stores the result in a network share for downstream analytics that expect 8‑bit per channel images.
 */