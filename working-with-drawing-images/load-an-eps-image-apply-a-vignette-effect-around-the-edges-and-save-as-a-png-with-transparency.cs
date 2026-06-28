using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var eps = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();

                using (var ms = new MemoryStream())
                {
                    eps.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (var raster = (RasterImage)Image.Load(ms))
                    {
                        int width = raster.Width;
                        int height = raster.Height;

                        var rect = new Rectangle(0, 0, width, height);
                        int[] pixels = raster.LoadArgb32Pixels(rect);

                        double cx = width / 2.0;
                        double cy = height / 2.0;
                        double maxDist = Math.Sqrt(cx * cx + cy * cy);

                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                int idx = y * width + x;
                                int argb = pixels[idx];

                                byte a = (byte)((argb >> 24) & 0xFF);
                                byte r = (byte)((argb >> 16) & 0xFF);
                                byte g = (byte)((argb >> 8) & 0xFF);
                                byte b = (byte)(argb & 0xFF);

                                double dx = x - cx;
                                double dy = y - cy;
                                double dist = Math.Sqrt(dx * dx + dy * dy);
                                double factor = 1.0 - Math.Pow(dist / maxDist, 2);
                                if (factor < 0) factor = 0;

                                r = (byte)(r * factor);
                                g = (byte)(g * factor);
                                b = (byte)(b * factor);
                                a = (byte)(a * factor);

                                pixels[idx] = (a << 24) | (r << 16) | (g << 8) | b;
                            }
                        }

                        raster.SaveArgb32Pixels(rect, pixels);
                        raster.Save(outputPath, new PngOptions());
                    }
                }
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
 * 1. When a developer needs to convert a vector EPS logo into a web‑ready PNG with transparent background and a soft vignette border for branding on a website.
 * 2. When an e‑commerce platform must display product illustrations originally supplied as EPS files with a subtle edge fade to blend with page backgrounds.
 * 3. When a marketing automation script generates promotional banners by rasterizing EPS artwork, applying a vignette effect, and saving as PNG for email campaigns.
 * 4. When a desktop publishing tool imports EPS icons, adds a vignette to focus viewer attention, and exports them as PNG files with an alpha channel for UI design.
 * 5. When a batch processing job processes a folder of EPS diagrams, adds a vignette to soften corners, and saves them as transparent PNGs for inclusion in PowerPoint presentations.
 */