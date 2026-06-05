using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string tempPngPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".temp.png");
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Rasterize SVG to temporary PNG
                using (Image svgImage = Image.Load(inputPath))
                {
                    PngOptions rasterOptions = new PngOptions();
                    rasterOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                    svgImage.Save(tempPngPath, rasterOptions);
                }

                // Apply motion blur filter to the rasterized PNG
                using (Image rasterImage = Image.Load(tempPngPath))
                {
                    RasterImage raster = (RasterImage)rasterImage;
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(8, 1.0, 60.0));
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    raster.Save(outputPath, new PngOptions());
                }

                // Delete temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When a developer needs to generate web‑ready PNG thumbnails from a collection of SVG icons and add a motion‑blur effect to simulate movement in a UI carousel.
 * 2. When an e‑learning platform must convert vector illustrations into raster PNG slides and apply a consistent motion blur of size 8 at 60° to create a dynamic visual transition.
 * 3. When a marketing automation script has to process dozens of SVG logos, rasterize them to PNG, and add a motion blur filter to produce stylized assets for social media posts.
 * 4. When a game development pipeline requires batch conversion of SVG assets into PNG sprites with a motion blur effect to give the impression of speed in 2‑D animations.
 * 5. When a reporting tool needs to transform SVG charts into PNG images and apply a motion blur of size 8, angle 60°, to highlight trend lines in printed PDFs.
 */