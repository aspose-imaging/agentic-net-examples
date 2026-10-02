// HOW-TO: Batch Convert WMF Files to Transparent 32‑Bit PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var file in files)
            {
                if (!file.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    continue;
                }

                using (Image image = Image.Load(file))
                {
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    })
                    {
                        image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate web‑ready PNG icons from a collection of legacy WMF graphics while preserving transparency.
 * 2. When an automated build process must convert multiple WMF assets into 32‑bit PNGs for inclusion in a mobile app.
 * 3. When a reporting tool requires high‑quality PNG charts derived from WMF files without manual conversion.
 * 4. When you are migrating a design library and need to batch export WMF logos to PNG with alpha channel support.
 * 5. When a server‑side service has to process incoming WMF uploads and store them as transparent PNGs for downstream image processing.
 */
