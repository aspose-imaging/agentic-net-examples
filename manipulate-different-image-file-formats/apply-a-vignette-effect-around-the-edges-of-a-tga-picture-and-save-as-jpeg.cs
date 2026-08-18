// HOW-TO: Apply Vignette Effect to TGA Image and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(raster);
                int steps = 10;
                int width = raster.Width;
                int height = raster.Height;

                for (int i = 0; i < steps; i++)
                {
                    double factor = (double)i / steps;
                    int insetX = (int)(factor * width / 2);
                    int insetY = (int)(factor * height / 2);
                    Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(insetX, insetY, width - 2 * insetX, height - 2 * insetY);
                    int alpha = (int)(255 * (1 - factor));
                    SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.FromArgb(alpha, 0, 0, 0));
                    graphics.FillEllipse(brush, rect);
                }

                var jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to add a subtle dark border to a TGA texture before publishing it as a JPEG for web galleries.
 * 2. When converting legacy TGA assets from a game project to JPEG while automatically applying a vignette to improve visual focus.
 * 3. When generating thumbnail previews of high‑resolution TGA files with a vignette effect for a photo‑management application.
 * 4. When preparing TGA screenshots for email newsletters and want a smooth dark fade around the edges without manual editing.
 * 5. When automating batch processing of TGA graphics to JPEG with a built‑in vignette for consistent branding across marketing materials.
 */
