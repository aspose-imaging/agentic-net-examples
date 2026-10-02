// HOW-TO: Add Semi Transparent Text Watermark to Horizontally Merged JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = { "input1.jpg", "input2.jpg" };
            string outputPath = "output/merged.jpg";

            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                Graphics graphics = new Graphics(canvas);
                Font font = new Font("Arial", 48);
                Color brushColor = Color.FromArgb(128, 255, 255, 255);
                SolidBrush brush = new SolidBrush(brushColor);
                string watermark = "Sample Watermark";
                graphics.DrawString(watermark, font, brush, new PointF(totalWidth - 200, maxHeight - 60));

                canvas.Save();
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
 * 1. When you need to combine multiple product photos side‑by‑side and brand the resulting image with a translucent company logo using C#.
 * 2. When creating a single panoramic view from several JPEG snapshots and want to overlay a semi‑transparent disclaimer or copyright notice.
 * 3. When generating printable catalogs where each merged image must include a faint “Sample” watermark to prevent unauthorized use.
 * 4. When automating the preparation of social‑media banners that stitch together promotional JPEGs and add a subtle text overlay for campaign tracking.
 * 5. When developing a web service that receives separate JPEG uploads, merges them horizontally, and returns the composite with a semi‑transparent watermark for security compliance.
 */
