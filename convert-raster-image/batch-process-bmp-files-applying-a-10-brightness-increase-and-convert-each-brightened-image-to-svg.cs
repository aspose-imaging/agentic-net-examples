// HOW-TO: Batch Increase Brightness of BMP Images and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                if (!Path.GetExtension(inputPath).Equals(".bmp", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".svg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    if (!raster.IsCached) raster.CacheData();
                    raster.AdjustBrightness(25); // approximate 10% increase

                    using (SvgOptions svgOptions = new SvgOptions())
                    {
                        svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = raster.Width,
                            PageHeight = raster.Height
                        };
                        raster.Save(outputPath, svgOptions);
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
 * 1. When you need to prepare a set of legacy BMP graphics for web display by brightening them and converting them to scalable SVG files.
 * 2. When an automated build pipeline must enhance the visibility of scanned BMP assets before generating vector versions for responsive UI components.
 * 3. When a desktop application processes user‑uploaded BMP photos, applies a uniform brightness boost, and saves them as SVG for further editing.
 * 4. When a reporting tool converts batch BMP charts into SVG while adjusting brightness to match a corporate theme.
 * 5. When migrating a legacy image library, you want to programmatically increase brightness of each BMP and output SVGs for modern browsers.
 */
