using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
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
                DngImage dng = (DngImage)image;

                // Create graphics for drawing
                Graphics graphics = new Graphics(dng);

                // Define semi‑transparent brush
                SolidBrush brush = new SolidBrush();
                brush.Color = Color.FromArgb(128, 255, 255, 255); // 50% transparent white

                // Define font
                Font font = new Font("Arial", 48);

                // Draw watermark text
                graphics.DrawString("Watermark", font, brush, new Point(50, 50));

                // Save as PNG
                dng.Save(outputPath, new PngOptions());
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
 * 1. When a photographer wants to protect raw DNG files by adding a semi‑transparent watermark before publishing them as PNGs on a website.
 * 2. When an e‑commerce platform needs to overlay copyright text on high‑resolution raw images (DNG) and deliver them as lightweight PNG thumbnails.
 * 3. When a mobile app backend processes user‑uploaded raw photos, adds branding with a translucent text layer, and stores the result in PNG format for faster loading.
 * 4. When a digital asset management system must batch‑process DNG files to embed a 50% transparent watermark and convert them to PNG for archival and preview purposes.
 * 5. When a developer integrates Aspose.Imaging in a C# workflow to ensure raw camera images are watermarked and saved as PNGs for compliance with licensing requirements.
 */