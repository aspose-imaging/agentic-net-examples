// HOW-TO: Add Semi Transparent Text Watermark to DNG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dng";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dng.DngImage dng = (Aspose.Imaging.FileFormats.Dng.DngImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(dng);

                SolidBrush brush = new SolidBrush();
                brush.Color = Color.FromArgb(128, 255, 255, 255); // 50% transparent white
                brush.Opacity = 100;

                Font font = new Font("Arial", 48);

                int x = dng.Width - 300;
                int y = dng.Height - 100;

                graphics.DrawString("Watermark", font, brush, new Point(x, y));

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
 * 1. When a photographer needs to embed a semi‑transparent copyright notice onto RAW DNG files before converting them to PNG for web galleries.
 * 2. When an e‑commerce platform wants to protect product photos captured in DNG format by adding a faint brand logo and then deliver them as PNG thumbnails.
 * 3. When a mobile app processes user‑uploaded DNG images, applies a translucent watermark for authentication, and stores the result as a PNG for faster loading.
 * 4. When a digital archivist must batch‑watermark high‑resolution DNG scans with a transparent text label and export them to PNG for archival distribution.
 * 5. When a marketing team requires automated C# code to place a semi‑transparent promotional text on DNG images and save the watermarked output as PNG for social media.
 */
