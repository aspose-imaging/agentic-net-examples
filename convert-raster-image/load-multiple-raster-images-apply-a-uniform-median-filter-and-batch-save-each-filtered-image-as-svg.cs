// HOW-TO: Batch Apply Median Filter to Images and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new MedianFilterOptions(3));

                    using (var svgOptions = new SvgOptions())
                    {
                        image.Save(outputPath, svgOptions);
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
 * 1. When you need to clean up noise in a folder of scanned photos before converting them to scalable SVG graphics for web display.
 * 2. When an automated pipeline must process dozens of bitmap files, apply a uniform median blur, and generate vector‑compatible SVG files for further editing.
 * 3. When a desktop application has to import various image formats, denoise them with a 3×3 median filter, and export each result as an SVG for printing at any resolution.
 * 4. When a data‑visualization tool requires pre‑filtered raster images to be transformed into SVGs so they can be styled with CSS.
 * 5. When a batch job must read images from a directory, apply the same image filter to all of them, and store the filtered output in a separate folder as SVG files for archival.
 */
