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
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
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
 * 1. When a developer needs to batch‑process a multi‑page PNG invoice archive, apply a custom sharpening kernel whose coefficients sum to one, and save each page as an individual PNG file.
 * 2. When an application must import a multi‑frame PNG sprite sheet, apply a normalized blur filter via a custom kernel to every frame, and export the processed frames for use in a game engine.
 * 3. When a medical imaging system receives multi‑page PNG scans, applies a noise‑reduction kernel with unit sum to preserve overall intensity, and writes each cleaned page to a secure output folder.
 * 4. When a document‑management workflow extracts each page of a multi‑page PNG report, enhances contrast with a custom edge‑detect kernel that is sum‑normalized, and stores the enhanced pages for archival.
 * 5. When a web service converts multi‑page PNG PDFs into individual PNG images, applies a custom sharpening kernel that maintains brightness (sum = 1), and saves each page to a CDN‑ready directory.
 */