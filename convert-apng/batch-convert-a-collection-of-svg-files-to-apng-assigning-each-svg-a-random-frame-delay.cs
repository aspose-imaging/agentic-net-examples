using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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
            if (files.Length == 0)
            {
                Console.WriteLine("No SVG files found in the input directory.");
                return;
            }

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
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
 * 1. When a developer needs to generate a set of animated icons for a web dashboard by batch‑converting designer‑provided SVG files into APNGs with random frame delays to create a lively UI.
 * 2. When an e‑learning platform must automatically transform a collection of vector illustrations into animated PNGs so each slide displays a subtly different animation speed without manual editing.
 * 3. When a mobile game studio wants to turn a library of SVG assets into APNG sprites with random frame delays to add visual variety to character animations.
 * 4. When an e‑commerce site requires automated conversion of product vector graphics into animated PNG thumbnails that play at different speeds to attract shoppers.
 * 5. When a marketing team needs to produce a series of animated social‑media stickers from SVG templates, using C# batch conversion to APNG with random delays for each sticker to keep the content dynamic.
 */