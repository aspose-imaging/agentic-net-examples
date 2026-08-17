// HOW-TO: Batch Convert SVG Icons to 32‑Bit PNGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "C:\\icons\\svg";
            string outputFolder = "C:\\icons\\png";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] files = Directory.GetFiles(inputFolder, "*.svg");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    int width = svgImage.Width;
                    int height = svgImage.Height;
                    int offsetX = 5;
                    int offsetY = 5;

                    // Rasterize SVG to an in‑memory PNG
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions,
                            BitDepth = 32
                        };
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage rasterSvg = (RasterImage)Image.Load(ms))
                        {
                            // Create a canvas larger than the original to accommodate the shadow
                            using (Image canvas = Image.Create(pngOptions, width + offsetX, height + offsetY))
                            {
                                Graphics graphics = new Graphics(canvas);
                                graphics.Clear(Color.Transparent);

                                // Draw a semi‑transparent black rectangle as a simple drop shadow
                                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0)))
                                {
                                    graphics.FillRectangle(shadowBrush, offsetX, offsetY, width, height);
                                }

                                // Draw the rasterized SVG on top of the shadow
                                graphics.DrawImage(rasterSvg, new Point(0, 0));

                                // Save the final PNG
                                canvas.Save(outputPath, pngOptions);
                            }
                        }
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
 * 1. When you need to automatically rasterize a large collection of SVG icons into high‑quality 32‑bit PNG files for a web or mobile UI.
 * 2. When you want to generate PNG assets from SVG source files in a build pipeline without manually opening each file.
 * 3. When you are preparing icon sets for a game engine that requires PNG images with full alpha channel support.
 * 4. When you must ensure consistent image dimensions while converting SVG vectors to raster PNGs using Aspose.Imaging in C#.
 * 5. When you need to script a folder‑to‑folder conversion that creates PNGs with 32‑bit color depth for print‑ready graphics.
 */
