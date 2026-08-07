using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    // Rasterize SVG to PNG in memory
                    using (MemoryStream rasterStream = new MemoryStream())
                    {
                        using (PngOptions rasterOptions = new PngOptions())
                        {
                            rasterOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageSize = ((SvgImage)svgImage).Size
                            };
                            svgImage.Save(rasterStream, rasterOptions);
                        }

                        rasterStream.Position = 0;

                        // Load rasterized PNG and convert to monochrome
                        using (RasterImage raster = (RasterImage)Image.Load(rasterStream))
                        {
                            raster.CacheData();
                            raster.Grayscale();
                            raster.BinarizeFixed(128);

                            using (PngOptions finalOptions = new PngOptions())
                            {
                                finalOptions.ColorType = PngColorType.Grayscale;
                                raster.Save(outputPath, finalOptions);
                            }
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
 * 1. When a developer needs to create monochrome PNG versions of a collection of SVG icons for a dark‑theme mobile app, this code batch‑converts and saves the assets in one step.
 * 2. When a UI designer wants to generate high‑resolution PNG sprites from SVG logos for a web dashboard that uses a dark background, the script automates the rasterization process.
 * 3. When a CI/CD pipeline must produce production‑ready PNG icons from source SVG files for a Windows desktop application’s dark mode, the code provides fast, repeatable batch conversion.
 * 4. When an e‑learning platform requires black‑on‑white PNG illustrations derived from SVG diagrams to ensure readability in its dark‑theme player, this routine handles the conversion automatically.
 * 5. When a game developer needs to convert a set of SVG asset files into monochrome PNG textures for use in a night‑mode UI skin, the program efficiently processes the entire folder.
 */