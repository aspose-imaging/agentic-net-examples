// HOW-TO: Add Drop Shadow to Multiple SVG Icons and Export as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (Image svgImage = Image.Load(inputPath))
                {
                    int width = svgImage.Width;
                    int height = svgImage.Height;
                    int shadowOffset = 5;

                    int canvasWidth = width + shadowOffset * 2;
                    int canvasHeight = height + shadowOffset * 2;

                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    FileCreateSource source = new FileCreateSource(outputPath, false);
                    PngOptions pngOptions = new PngOptions
                    {
                        Source = source,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (Image canvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
                    {
                        Graphics graphics = new Graphics(canvas);
                        graphics.Clear(Color.Transparent);

                        using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0)))
                        {
                            Rectangle shadowRect = new Rectangle(shadowOffset, shadowOffset, width, height);
                            graphics.FillRectangle(shadowBrush, shadowRect);
                        }

                        graphics.DrawImage(svgImage, new Point(shadowOffset, shadowOffset));

                        canvas.Save();
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
 * 1. When you need to apply a consistent drop‑shadow effect to a whole collection of SVG icons before publishing them as high‑quality 32‑bit PNGs for a web UI.
 * 2. When you want to automate the conversion of vector assets from a design folder into raster PNG files with added depth for use in a mobile application.
 * 3. When a branding team requires every SVG logo to be exported with a uniform shadow and exact color depth to maintain visual consistency across marketing materials.
 * 4. When generating thumbnail previews of SVG illustrations for an online catalog, and the thumbnails must include a subtle shadow and be saved as PNG with full color fidelity.
 * 5. When preparing a set of SVG symbols for a game’s UI, and you need to batch‑process them to add a shadow and output 32‑bit PNGs that the engine can load directly.
 */
