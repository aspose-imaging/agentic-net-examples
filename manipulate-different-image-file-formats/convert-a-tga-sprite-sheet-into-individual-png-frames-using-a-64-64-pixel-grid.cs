using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/sprites.tga";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TGA sprite sheet as a raster image
            using (RasterImage sheet = (RasterImage)Image.Load(inputPath))
            {
                const int frameWidth = 64;
                const int frameHeight = 64;

                int columns = sheet.Width / frameWidth;
                int rows = sheet.Height / frameHeight;
                int index = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        var sourceRect = new Rectangle(col * frameWidth, row * frameHeight, frameWidth, frameHeight);
                        int[] pixels = sheet.LoadArgb32Pixels(sourceRect);

                        // Create a new PNG image for the frame
                        using (RasterImage frame = (RasterImage)Image.Create(new PngOptions(), frameWidth, frameHeight))
                        {
                            frame.SaveArgb32Pixels(new Rectangle(0, 0, frameWidth, frameHeight), pixels);

                            string outputPath = $"output/frame_{index}.png";
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            frame.Save(outputPath, new PngOptions());
                        }

                        index++;
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
 * 1. When a game developer needs to extract individual animation frames from a TGA sprite sheet and save them as separate 64×64 PNG files for use in a Unity project.
 * 2. When a UI designer wants to convert a large TGA icon atlas into a set of 64×64 PNG icons for a responsive web application.
 * 3. When a mobile app team must preprocess legacy TGA textures into PNG frames to improve loading performance on iOS and Android devices.
 * 4. When an e‑learning platform requires splitting a TGA tutorial sheet into separate PNG steps for interactive slide presentations.
 * 5. When a digital artist automates the batch conversion of a TGA sprite sheet into PNG frames to feed into an animation pipeline that expects 64‑pixel tiles.
 */