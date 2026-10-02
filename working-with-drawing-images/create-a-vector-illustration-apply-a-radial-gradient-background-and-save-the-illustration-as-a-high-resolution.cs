// HOW-TO: Create High-Resolution TIFF with Radial Gradient and Vector Shapes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.tiff";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 2000;
            int height = 2000;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            using (Image image = Image.Create(tiffOptions, width, height))
            {
                RasterImage raster = (RasterImage)image;
                int[] pixels = new int[width * height];
                double maxDist = Math.Sqrt((width / 2.0) * (width / 2.0) + (height / 2.0) * (height / 2.0));

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int idx = y * width + x;
                        double dx = x - width / 2.0;
                        double dy = y - height / 2.0;
                        double dist = Math.Sqrt(dx * dx + dy * dy);
                        double t = Math.Min(1.0, dist / maxDist);
                        int r = (int)(255 * t);
                        int g = (int)(255 * t);
                        int b = 255;
                        pixels[idx] = Color.FromArgb(255, r, g, b).ToArgb();
                    }
                }

                raster.SaveArgb32Pixels(raster.Bounds, pixels);

                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Red, 5);
                graphics.DrawEllipse(pen, (width / 2) - 200, (height / 2) - 200, 400, 400);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Yellow)))
                {
                    graphics.FillEllipse(brush, (width / 2) - 100, (height / 2) - 100, 200, 200);
                }

                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to generate a printable poster‑size image with a smooth radial background and vector graphics for a marketing campaign.
 * 2. When you want to programmatically create a high‑resolution TIFF for archival or publishing workflows that require lossless quality.
 * 3. When you need to add custom shapes like ellipses on top of a gradient background for scientific visualizations or diagrams.
 * 4. When you are building a server‑side service that produces on‑the‑fly graphics for PDF reports or print‑ready files.
 * 5. When you must automate the creation of large‑format images with specific color blends and transparent overlays for branding assets.
 */
