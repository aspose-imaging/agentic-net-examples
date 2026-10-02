// HOW-TO: Batch Convert SVG Icons To Monochrome PNGs In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string file in files)
            {
                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(file);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                using (Image svgImage = Image.Load(inputPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterCachedImage raster = (RasterCachedImage)Image.Load(ms))
                        {
                            if (!raster.IsCached) raster.CacheData();
                            raster.Grayscale();
                            raster.BinarizeFixed(128);
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            var outPngOptions = new PngOptions();
                            raster.Save(outputPath, outPngOptions);
                        }
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
 * 1. When you need to generate dark‑theme ready icons by turning a collection of SVG vector graphics into black‑and‑white PNG files for a Windows desktop application.
 * 2. When you want to automate the preprocessing of SVG assets for a mobile app, converting them to grayscale PNGs and then binarizing them to reduce file size and improve contrast on OLED screens.
 * 3. When a CI/CD pipeline must batch‑process design assets, converting SVG logos into monochrome PNGs for inclusion in PDF reports generated with .NET.
 * 4. When you are building a web dashboard that requires high‑contrast icons, using Aspose.Imaging in C# to rasterize SVGs and produce binary PNGs that render consistently across browsers.
 * 5. When you need to prepare a set of SVG symbols for a printing workflow, converting them to grayscale PNGs and applying a fixed threshold to ensure crisp black‑and‑white output for laser printers.
 */
