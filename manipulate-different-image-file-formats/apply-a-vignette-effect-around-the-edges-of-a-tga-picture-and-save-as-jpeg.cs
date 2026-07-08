using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tga";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(image.Width, image.Height),
                    Color.FromArgb(0, 0, 0, 0),
                    Color.FromArgb(180, 0, 0, 0)))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, 0, image.Width, image.Height));
                }

                JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When a game developer needs to convert high‑resolution TGA textures to web‑friendly JPEGs while adding a dark vignette border to improve visual focus.
 * 2. When a photo‑editing application must batch‑process TGA screenshots, apply a gradient vignette effect, and output compressed JPEG files for faster sharing.
 * 3. When an e‑commerce platform wants to import product renderings stored as TGA, add a subtle edge fade using a linear gradient brush, and store the result as JPEG for product pages.
 * 4. When a scientific imaging tool requires converting raw TGA microscopy images to JPEG format with a vignette overlay to emphasize central details in reports.
 * 5. When a mobile app backend processes user‑uploaded TGA avatars, applies a vignette effect for aesthetic consistency, and saves them as JPEGs for display on devices.
 */