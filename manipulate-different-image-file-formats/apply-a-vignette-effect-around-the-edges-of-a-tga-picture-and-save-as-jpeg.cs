// HOW-TO: Add Vignette Effect to TGA Image and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tga";
        string outputPath = "output\\result.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int width = image.Width;
                int height = image.Height;

                Graphics graphics = new Graphics(image);
                SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
                graphics.FillEllipse(brush, new Rectangle(0, 0, width, height));

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to apply a darkened border (vignette) to a game asset stored as a TGA file before converting it to a web‑friendly JPEG for online galleries.
 * 2. When you want to batch‑process high‑resolution TGA screenshots, add a subtle vignette for visual emphasis, and output compressed JPEGs for faster loading.
 * 3. When a photo‑editing application requires converting legacy TGA textures with a vignette overlay into JPEG thumbnails for preview panels.
 * 4. When an e‑commerce platform must transform product renderings in TGA format, add a professional vignette effect, and store them as JPEGs for product listings.
 * 5. When a reporting tool generates charts as TGA images, needs to enhance them with a vignette for aesthetic appeal, and then saves the final images as JPEGs for inclusion in PDF reports.
 */
