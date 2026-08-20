// HOW-TO: Create PNG with Vignette Effect from EPS in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var rasterOptions = new PngOptions();
                    epsImage.Save(ms, rasterOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        int width = raster.Width;
                        int height = raster.Height;

                        Graphics graphics = new Graphics(raster);
                        int steps = 10;
                        int maxAlpha = 180;
                        int minDim = Math.Min(width, height);
                        float stepSize = (float)minDim / (2 * steps);

                        for (int i = 0; i < steps; i++)
                        {
                            int inset = (int)(i * stepSize);
                            var rect = new Rectangle(inset, inset, width - 2 * inset, height - 2 * inset);
                            byte alpha = (byte)(maxAlpha * (i + 1) / steps);
                            var brush = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0));
                            graphics.FillEllipse(brush, rect);
                        }

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
 * 1. When you need to convert a vector EPS logo to a PNG thumbnail with a soft dark border for web display.
 * 2. When you want to add a vignette overlay to a rasterized EPS illustration before embedding it in a mobile app.
 * 3. When you must generate transparent PNG assets from EPS files while automatically applying a fade‑out edge for UI themes.
 * 4. When you are preparing print‑ready EPS artwork for online galleries and require a subtle vignette to focus viewer attention.
 * 5. When you automate batch processing of EPS diagrams into PNGs with consistent edge shading for presentation slides.
 */
