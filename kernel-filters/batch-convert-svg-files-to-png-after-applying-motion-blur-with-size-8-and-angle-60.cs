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
            string inputDirectory = "InputSvgs";
            string outputDirectory = "OutputPngs";

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

                using (Image vectorImage = Image.Load(inputPath))
                {
                    var rasterizationOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = vectorImage.Width,
                            PageHeight = vectorImage.Height,
                            BackgroundColor = Aspose.Imaging.Color.White
                        }
                    };

                    using (MemoryStream ms = new MemoryStream())
                    {
                        vectorImage.Save(ms, rasterizationOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(8, 1.0, 60.0));
                            var saveOptions = new PngOptions();
                            raster.Save(outputPath, saveOptions);
                        }
                    }
                }

                Console.WriteLine($"Processed: {inputPath} -> {outputPath}");
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
 * 1. When a web developer needs to generate blurred PNG thumbnails from a library of SVG icons using C# and Aspose.Imaging for faster page loading.
 * 2. When a marketing team wants to batch convert SVG artwork to PNG files with a consistent motion blur (size 8, angle 60) for eye‑catching social media graphics.
 * 3. When an e‑learning platform automatically rasterizes SVG diagrams into PNG slides and applies a motion blur effect to highlight directional flow in instructional content.
 * 4. When a desktop publishing application processes a collection of SVG logos and outputs PNG images with a motion blur filter to simulate movement in promotional materials.
 * 5. When a CI/CD pipeline uses C# and Aspose.Imaging to convert SVG assets to PNG with a predefined motion blur (size 8, angle 60) to ensure uniform branding across all generated assets.
 */