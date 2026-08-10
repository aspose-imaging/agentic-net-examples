// HOW-TO: Extract 64x64 PNG Frames from TGA Sprite Sheet in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sprite_sheet.tga";
            string outputDir = "Frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Aspose.Imaging.RasterImage sheet = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int frameWidth = 64;
                int frameHeight = 64;
                int cols = sheet.Width / frameWidth;
                int rows = sheet.Height / frameHeight;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        int x = col * frameWidth;
                        int y = row * frameHeight;
                        var rect = new Aspose.Imaging.Rectangle(x, y, frameWidth, frameHeight);
                        int[] pixels = sheet.LoadArgb32Pixels(rect);

                        string outputPath = Path.Combine(outputDir, $"frame_{row}_{col}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var source = new FileCreateSource(outputPath, false);
                        var pngOptions = new PngOptions() { Source = source };

                        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, frameWidth, frameHeight))
                        {
                            canvas.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, frameWidth, frameHeight), pixels);
                            canvas.Save();
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
 * 1. When a game developer needs to split a TGA sprite sheet into individual 64 × 64 PNG frames for character animation.
 * 2. When an asset pipeline requires converting legacy TGA texture atlases into separate PNG images for modern engines.
 * 3. When a UI designer wants to export each cell of a 64‑pixel grid from a TGA sprite sheet to use as icons in a C# application.
 * 4. When a mobile app needs to reduce memory usage by loading only the required PNG frames instead of the full TGA sheet.
 * 5. When an automated build script must batch‑process multiple TGA sprite sheets into PNG frames for continuous integration.
 */
