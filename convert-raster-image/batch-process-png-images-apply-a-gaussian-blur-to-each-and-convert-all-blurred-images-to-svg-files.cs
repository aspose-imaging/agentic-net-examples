// HOW-TO: Batch Apply Gaussian Blur to PNGs and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImagingNet
{
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
                    Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                    return;
                }

                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                string[] files = Directory.GetFiles(inputDirectory, "*.png");

                foreach (string inputPath in files)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        RasterImage raster = (RasterImage)image;

                        var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                        raster.Filter(raster.Bounds, blurOptions);

                        var svgOptions = new SvgOptions();
                        raster.Save(outputPath, svgOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically soften a large set of PNG icons before turning them into scalable SVG graphics for a web UI.
 * 2. When a graphics pipeline must preprocess product photos with a Gaussian blur and then export them as vector SVG files for print‑ready layouts.
 * 3. When a desktop application has to convert user‑uploaded PNG screenshots into blurred SVG diagrams for documentation generation.
 * 4. When a batch job has to reduce file size of PNG assets by applying a blur filter and then save them as SVG to enable infinite scaling on high‑resolution displays.
 * 5. When an automated build script must transform a folder of PNG maps into blurred SVG maps for use in interactive GIS applications.
 */
