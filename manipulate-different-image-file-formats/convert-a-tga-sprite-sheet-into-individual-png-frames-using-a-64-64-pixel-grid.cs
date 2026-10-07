// HOW-TO: Extract 64x64 PNG Frames from a TGA Sprite Sheet in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sprite.tga";
            string outputDir = "Frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (RasterImage sheet = (RasterImage)Image.Load(inputPath))
            {
                int frameWidth = 64;
                int frameHeight = 64;
                int columns = sheet.Width / frameWidth;
                int rows = sheet.Height / frameHeight;

                int[] sheetPixels = sheet.LoadArgb32Pixels(new Rectangle(0, 0, sheet.Width, sheet.Height));

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        int[] framePixels = new int[frameWidth * frameHeight];
                        for (int y = 0; y < frameHeight; y++)
                        {
                            int srcY = row * frameHeight + y;
                            Array.Copy(sheetPixels, srcY * sheet.Width + col * frameWidth, framePixels, y * frameWidth, frameWidth);
                        }

                        string outputPath = Path.Combine(outputDir, $"frame_{row}_{col}.png");

                        PngOptions options = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };

                        using (Image frameImage = Image.Create(options, frameWidth, frameHeight))
                        {
                            ((RasterImage)frameImage).SaveArgb32Pixels(new Rectangle(0, 0, frameWidth, frameHeight), framePixels);
                            frameImage.Save();
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
 * 1. When you need to break a large TGA sprite sheet into individual PNG images for use in a game engine.
 * 2. When you want to generate separate animation frames from a tiled texture atlas for UI animations.
 * 3. When you must convert legacy TGA assets to web‑friendly PNG files while preserving a fixed 64×64 grid layout.
 * 4. When you are preprocessing sprite sheets for a mobile app that only supports PNG image sequences.
 * 5. When you automate the extraction of sprite frames to feed into a machine‑learning model that requires individual PNG inputs.
 */
