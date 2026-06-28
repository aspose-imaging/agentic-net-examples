using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\image.png";
        string outputPath = "output\\result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to automatically remove the background from product photos in PNG format and smooth the edges using a custom feathering radius before uploading to an e‑commerce site.
 * 2. When a developer wants to generate transparent PNG avatars from user‑uploaded images by applying graph‑cut based auto‑masking with adjustable feathering to maintain a natural look.
 * 3. When a developer is building a batch image‑processing tool that isolates foreground objects in PNG files and saves the results with consistent edge softness for use in marketing materials.
 * 4. When a developer must prepare PNG assets for a mobile game by extracting characters from complex scenes using AutoMaskingGraphCutOptions with a specific feather radius to avoid jagged borders.
 * 5. When a developer creates a document‑automation workflow that extracts logos from PNG scans, applies graph‑cut masking with custom feathering, and stores the cleaned images for branding guidelines.
 */