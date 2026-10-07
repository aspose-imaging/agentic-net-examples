// HOW-TO: Increase BMP Contrast By 15% And Export As SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.bmp";
        string outputPath = "Output\\enhanced.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached) raster.CacheData();

                raster.AdjustContrast(0.15f);

                using (SvgOptions options = new SvgOptions())
                {
                    options.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = raster.Width,
                        PageHeight = raster.Height
                    };
                    raster.Save(outputPath, options);
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
 * 1. When you need to enhance the visual clarity of legacy BMP graphics before converting them to scalable SVG for web display.
 * 2. When a desktop application must programmatically boost contrast of scanned bitmap images and store the result as vector‑friendly SVG files.
 * 3. When an automated batch process has to prepare BMP assets for responsive UI by increasing contrast and raster‑to‑vector converting them with Aspose.Imaging in C#.
 * 4. When a reporting tool requires high‑contrast bitmap charts to be embedded in SVG charts for resolution‑independent printing.
 * 5. When a migration script upgrades old BMP icons by adjusting their contrast and saving them as SVG to reduce file size and improve scalability.
 */
