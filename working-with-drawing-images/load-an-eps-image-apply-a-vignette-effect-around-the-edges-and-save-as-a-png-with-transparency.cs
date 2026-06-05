using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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
                var pngOptions = new PngOptions();

                using (var memory = new MemoryStream())
                {
                    epsImage.Save(memory, pngOptions);
                    memory.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(memory))
                    {
                        Graphics graphics = new Graphics(raster);
                        int steps = 10;
                        for (int i = 0; i < steps; i++)
                        {
                            double factor = 1.0 - i * 0.1;
                            int ellipseWidth = (int)(raster.Width * factor);
                            int ellipseHeight = (int)(raster.Height * factor);
                            int x = (raster.Width - ellipseWidth) / 2;
                            int y = (raster.Height - ellipseHeight) / 2;
                            int alpha = (int)(255 * (1.0 - factor));
                            Pen pen = new Pen(Color.FromArgb(alpha, 0, 0, 0));
                            graphics.DrawEllipse(pen, new Rectangle(x, y, ellipseWidth, ellipseHeight));
                        }

                        raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert vector EPS artwork into a web‑ready PNG with a subtle vignette border for a marketing banner.
 * 2. When a C# application must display a printable EPS logo on a transparent background while adding a dark edge fade for a mobile app splash screen.
 * 3. When an automated image‑processing pipeline requires rasterizing EPS files, applying an elliptical vignette effect, and saving the result as a PNG with alpha channel for UI overlays.
 * 4. When a designer’s workflow involves programmatically adding a vignette to EPS illustrations before embedding them in PDF reports that use PNG thumbnails.
 * 5. When a .NET service generates product thumbnails from EPS source files, adds a soft vignette to focus attention, and outputs PNG images with transparency for e‑commerce sites.
 */