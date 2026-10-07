// HOW-TO: Convert SVG To PNG With Original Dimensions In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageWidth = svgImage.Width;
                rasterOptions.PageHeight = svgImage.Height;
                rasterOptions.BackgroundColor = Color.White;

                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When you need to render an SVG graphic as a high‑resolution PNG for web thumbnails using C#.
 * 2. When a reporting tool requires vector icons to be converted to raster images to embed in PDF documents.
 * 3. When an automated build pipeline must batch‑process SVG assets and generate PNGs with a white background for mobile apps.
 * 4. When you want to preserve the original SVG dimensions while converting to PNG for accurate layout calculations in a .NET application.
 * 5. When integrating Aspose.Imaging into a C# service that converts user‑uploaded SVG files to PNG for storage and preview.
 */
