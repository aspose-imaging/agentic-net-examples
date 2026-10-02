// HOW-TO: Create Animated GIF From PNG Frames With Custom Fonts In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string fontFolder = "fonts";
            string frame1Path = "frame1.png";
            string frame2Path = "frame2.png";
            string outputPath = "output.gif";

            // Input file existence checks
            if (!File.Exists(frame1Path))
            {
                Console.Error.WriteLine($"File not found: {frame1Path}");
                return;
            }
            if (!File.Exists(frame2Path))
            {
                Console.Error.WriteLine($"File not found: {frame2Path}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load first frame with custom fonts and draw text
            var loadOptions1 = new LoadOptions();
            loadOptions1.AddCustomFontSource((args) =>
            {
                string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var fontFile in Directory.GetFiles(fontsPath))
                    {
                        byte[] fontBytes = File.ReadAllBytes(fontFile);
                        string fontName = Path.GetFileNameWithoutExtension(fontFile);
                        result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                    }
                }
                return result.ToArray();
            }, fontFolder);

            using (RasterImage firstImg = (RasterImage)Image.Load(frame1Path, loadOptions1))
            {
                var graphics = new Graphics(firstImg);
                var font = new Font("CustomFont", 24);
                using (var brush = new SolidBrush(Color.Black))
                {
                    graphics.DrawString("Sample Text", font, brush, new PointF(10, 10));
                }

                int width = firstImg.Width;
                int height = firstImg.Height;

                var gifOptions = new GifOptions();

                using (GifImage gif = (GifImage)Image.Create(gifOptions, width, height))
                {
                    gif.AddPage(firstImg);

                    // Load second frame with custom fonts and draw text
                    var loadOptions2 = new LoadOptions();
                    loadOptions2.AddCustomFontSource((args) =>
                    {
                        string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                        var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                        if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                        {
                            foreach (var fontFile in Directory.GetFiles(fontsPath))
                            {
                                byte[] fontBytes = File.ReadAllBytes(fontFile);
                                string fontName = Path.GetFileNameWithoutExtension(fontFile);
                                result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                            }
                        }
                        return result.ToArray();
                    }, fontFolder);

                    using (RasterImage secondImg = (RasterImage)Image.Load(frame2Path, loadOptions2))
                    {
                        var graphics2 = new Graphics(secondImg);
                        var font2 = new Font("CustomFont", 24);
                        using (var brush2 = new SolidBrush(Color.Black))
                        {
                            graphics2.DrawString("Sample Text", font2, brush2, new PointF(10, 10));
                        }

                        gif.AddPage(secondImg);
                    }

                    // Save the animated GIF
                    gif.Save(outputPath, gifOptions);
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
 * 1. When you need to generate an animated banner where each frame’s caption uses a brand‑specific font that isn’t installed on the server.
 * 2. When you want to overlay dynamic text on a series of PNG images and combine them into a single GIF for email marketing campaigns.
 * 3. When building a game scoreboard that displays scores in a custom typeface across animated GIF frames.
 * 4. When creating instructional tutorials that require consistent custom‑styled text on each step’s image before exporting as an animated GIF.
 * 5. When automating the production of social‑media memes that combine multiple PNG scenes with user‑provided fonts into a looping GIF.
 */
