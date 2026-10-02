// HOW-TO: Create 3D Extruded PNG from SVG with High Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int depth = 20;
                int canvasWidth = vectorImage.Width + depth;
                int canvasHeight = vectorImage.Height + depth;

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300)
                };

                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    for (int i = depth; i > 0; i--)
                    {
                        graphics.DrawImage(vectorImage, new Aspose.Imaging.Point(i, i));
                    }

                    graphics.DrawImage(vectorImage, new Aspose.Imaging.Point(0, 0));

                    canvas.Save();
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
 * 1. When you need to generate a printable, high‑resolution PNG of a logo that appears with a 3‑D shadow effect for marketing materials.
 * 2. When you want to convert SVG icons into raster images with depth to use in desktop applications that require PNG assets.
 * 3. When you must create layered product images with extrusion for e‑commerce catalogs while preserving vector quality.
 * 4. When you need to automate batch processing of vector drawings into 300 DPI PNG files with a simple 3‑D look for reports.
 * 5. When you are building a C# service that renders SVG diagrams as high‑resolution PNG thumbnails with a subtle extrusion for UI previews.
 */
