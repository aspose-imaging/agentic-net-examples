// HOW-TO: Batch Convert EMF and WMF Files to PNG with Specified DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            int targetDpi = 300;

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            var files = Directory.GetFiles(inputDirectory)
                .Where(f => f.EndsWith(".emf", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    PngOptions options = new PngOptions();
                    options.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(targetDpi, targetDpi);
                    image.Save(outputPath, options);
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
 * 1. When a developer needs to prepare vector drawings from legacy Windows Metafile formats for high‑resolution web publishing, they can batch convert EMF and WMF to PNG at 300 DPI.
 * 2. When an automated build pipeline must generate print‑ready raster images from design assets stored as EMF/WMF, this code creates uniform‑DPI PNGs for downstream printing tools.
 * 3. When a document management system imports mixed Metafile graphics and requires all images to be stored as lossless PNGs with consistent resolution, the script processes the entire input folder in one run.
 * 4. When a migration project moves legacy engineering diagrams from EMF/WMF to a modern image repository, the code ensures each diagram is rasterized at the target DPI for accurate scaling.
 * 5. When a desktop application needs to display Metafile icons on high‑DPI monitors, developers can pre‑convert the icons to PNG at the desired DPI to avoid runtime scaling issues.
 */
