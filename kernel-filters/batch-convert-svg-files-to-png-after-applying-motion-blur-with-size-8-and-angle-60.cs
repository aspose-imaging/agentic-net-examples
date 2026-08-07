using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputSvg";
            string outputDirectory = "OutputPng";

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
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (MemoryStream ms = new MemoryStream())
                {
                    using (Image svgImage = Image.Load(inputPath))
                    {
                        var rasterOptions = new SvgRasterizationOptions
                        {
                            PageWidth = svgImage.Width,
                            PageHeight = svgImage.Height,
                            BackgroundColor = Color.White
                        };

                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        svgImage.Save(ms, pngOptions);
                    }

                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new MotionWienerFilterOptions(8, 1.0, 60.0));
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When a web developer needs to batch convert a library of SVG icons to PNG thumbnails with a 60‑degree motion blur (size 8) using Aspose.Imaging for .NET to improve page load speed.
 * 2. When a UI/UX designer wants to generate motion‑blurred PNG previews of vector assets from an SVG folder for inclusion in design system documentation.
 * 3. When an e‑commerce platform must automatically transform product SVG illustrations into blurred PNG images for promotional banners and email campaigns.
 * 4. When a game developer requires a script that rasterizes SVG sprites, applies a size‑8 motion blur at a 60° angle, and saves them as PNG files for background effects in a 2D game.
 * 5. When an automation tool processes a directory of corporate SVG logos, applies a 60° motion blur (size 8) and outputs PNG versions for printing or marketing collateral.
 */