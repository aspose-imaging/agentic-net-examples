using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dng";
            string outputPath = "output\\watermarked.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;

                // Create graphics for drawing
                Graphics graphics = new Graphics(dngImage);

                // Semi‑transparent white brush
                var brush = new SolidBrush(Aspose.Imaging.Color.FromArgb(128, 255, 255, 255));

                // Font for watermark text
                var font = new Font("Arial", 48);

                // Draw watermark text at position (10,10)
                graphics.DrawString("Watermark", font, brush, new PointF(10, 10));

                // Save as PNG
                dngImage.Save(outputPath, new PngOptions());
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
 * 1. When a photographer wants to embed a semi‑transparent copyright notice into raw DNG files before publishing them as PNGs for web galleries.
 * 2. When an e‑commerce platform needs to protect product photos captured in DNG format by adding a translucent watermark and converting them to PNG for faster page loads.
 * 3. When a mobile app developer processes user‑uploaded raw images, applies a branding overlay, and saves the result as a PNG for sharing on social media.
 * 4. When a digital archivist converts high‑resolution DNG scans to PNG while embedding a faint watermark to indicate the source repository.
 * 5. When a print‑on‑demand service adds a low‑opacity text label to raw camera files and outputs PNGs for preview generation in a C# ASP.NET application.
 */