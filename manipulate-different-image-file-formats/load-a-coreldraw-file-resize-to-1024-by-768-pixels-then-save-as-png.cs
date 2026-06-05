using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the CorelDRAW file, resize, and save as PNG
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                image.Resize(1024, 768);
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert legacy CorelDRAW (.cdr) artwork into web‑ready PNG thumbnails of 1024 × 768 pixels for an online portfolio.
 * 2. When an e‑commerce platform must automatically generate product preview images from designer‑provided CDR files and store them as PNGs at a fixed resolution.
 * 3. When a content management system imports client‑supplied CorelDRAW graphics and resizes them to 1024 × 768 before saving them as PNG for fast browser rendering.
 * 4. When a desktop application batch‑processes a folder of CDR files, resizing each to 1024 × 768 and exporting them as PNGs using Aspose.Imaging in C#.
 * 5. When a reporting tool needs to embed a CorelDRAW diagram into a PDF report, first converting the CDR to a 1024 × 768 PNG with C# code.
 */