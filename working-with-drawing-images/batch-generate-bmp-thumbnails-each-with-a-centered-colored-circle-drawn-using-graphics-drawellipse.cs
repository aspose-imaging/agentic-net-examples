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
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
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
 * 1. When a developer needs to create small BMP preview images for a gallery and highlight each preview with a colored circle overlay using Aspose.Imaging Graphics.DrawEllipse.
 * 2. When an e‑commerce platform must generate BMP thumbnails of product photos on the fly and add a brand‑color circle at the center to indicate availability status.
 * 3. When a desktop application processes scanned documents and produces BMP thumbnail icons with a red circle to mark pages that require review.
 * 4. When a reporting tool exports chart snapshots as BMP thumbnails and draws a green circle around the key data point for quick visual emphasis.
 * 5. When a game asset pipeline batches BMP sprite sheets, creates thumbnail previews, and draws a blue circle at the center to denote the primary animation frame.
 */