using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
        string outputPath = "merged_output.jpg";

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create JPEG canvas bound to the output file
        Source fileSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = fileSource, Quality = 90 };

        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            // Merge images horizontally onto the canvas
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Add semi‑transparent text watermark
            Graphics graphics = new Graphics(canvas);
            Font font = new Font("Arial", 48);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)); // 50% transparent red
            // Position watermark near bottom‑right corner
            int watermarkX = newWidth - 250;
            int watermarkY = newHeight - 70;
            graphics.DrawString("Watermark", font, brush, new PointF(watermarkX, watermarkY));

            // Save the bound canvas
            canvas.Save();
        }
    }
}