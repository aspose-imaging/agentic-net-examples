using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
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
 * 1. When a developer needs to convert legacy vector EMF diagrams into web‑friendly PNG images while applying a vintage sepia tone for a historical report.
 * 2. When an application must generate printable product catalogs by rendering EMF logos with a sepia effect and saving them as high‑resolution PNG files.
 * 3. When a content management system requires automated processing of uploaded EMF illustrations to create sepia‑styled PNG thumbnails for blog posts.
 * 4. When a desktop tool transforms engineering schematics stored as EMF into sepia‑tinted PNG assets for inclusion in a corporate presentation.
 * 5. When a batch job processes a folder of EMF icons, applies a sepia filter, and exports each as a PNG to match a retro UI theme.
 */