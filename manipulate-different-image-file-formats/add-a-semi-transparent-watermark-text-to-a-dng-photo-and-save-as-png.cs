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
        string inputPath = "input.dng";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "output\\watermarked.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;
                RasterImage raster = (RasterImage)dngImage;

                // Create graphics for drawing
                Graphics graphics = new Graphics(raster);

                // Semi‑transparent white brush (50% opacity)
                var brush = new SolidBrush(Color.FromArgb(128, 255, 255, 255));

                // Font for watermark text
                var font = new Font("Arial", 48);

                // Position the text roughly at the center
                float x = raster.Width / 2f - 100f;
                float y = raster.Height / 2f - 24f;
                graphics.DrawString("Watermark", font, brush, new PointF(x, y));

                // Save the result as PNG
                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a photographer wants to protect raw DNG images by embedding a semi‑transparent watermark before publishing them as PNG thumbnails on a website.
 * 2. When an e‑commerce platform needs to automatically add copyright text to high‑resolution DNG product photos and convert them to PNG for faster loading.
 * 3. When a mobile app backend processes user‑uploaded DNG files, applies a translucent watermark using Aspose.Imaging’s Graphics API, and stores the result as PNG for display.
 * 4. When a digital asset management system must batch‑process raw DNG files, overlaying a semi‑transparent label and saving the output in PNG format for archival preview.
 * 5. When a scientific imaging workflow requires adding a faint identifier to raw DNG microscope images and exporting them as PNG for inclusion in research reports.
 */