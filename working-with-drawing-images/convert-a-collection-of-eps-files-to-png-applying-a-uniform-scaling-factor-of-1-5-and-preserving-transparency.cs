// HOW-TO: Batch Convert EPS to PNG with 1.5x Scaling and Transparency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
                if (!inputPath.EndsWith(".eps", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
                {
                    int newWidth = (int)(epsImage.Width * 1.5);
                    int newHeight = (int)(epsImage.Height * 1.5);

                    var rasterOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageWidth = newWidth,
                        PageHeight = newHeight
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions,
                        Source = new FileCreateSource(outputPath, false)
                    };

                    epsImage.Save(outputPath, pngOptions);
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
 * 1. When you need to generate high‑resolution PNG thumbnails from a folder of EPS logos while keeping their transparent backgrounds.
 * 2. When an e‑commerce platform must resize vector product illustrations by 150 % and serve them as PNG images for web display.
 * 3. When a publishing workflow requires converting multiple EPS artwork files to PNG with consistent scaling for print‑to‑screen previews.
 * 4. When a design tool automates the export of EPS icons to PNG assets, preserving transparency and applying a uniform size increase.
 * 5. When a batch script processes incoming EPS files, enlarges them by a factor of 1.5, and saves the results as transparent PNGs for downstream processing.
 */
