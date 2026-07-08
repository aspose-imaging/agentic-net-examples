using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input TGA sprite sheet
            string inputPath = "sprite_sheet.tga";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the sprite sheet as a raster image
            using (RasterImage spriteSheet = (RasterImage)Image.Load(inputPath))
            {
                // Cache data for better performance
                if (!spriteSheet.IsCached) spriteSheet.CacheData();

                int frameWidth = 64;
                int frameHeight = 64;
                int columns = spriteSheet.Width / frameWidth;
                int rows = spriteSheet.Height / frameHeight;

                // Output directory for frames
                string outputDir = "Frames";
                Directory.CreateDirectory(outputDir);

                int frameIndex = 0;
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        // Define the region for the current frame
                        Aspose.Imaging.Rectangle region = new Aspose.Imaging.Rectangle(col * frameWidth, row * frameHeight, frameWidth, frameHeight);

                        // Build output file path
                        string outputPath = Path.Combine(outputDir, $"frame_{frameIndex}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the region as a PNG frame
                        using (PngOptions pngOptions = new PngOptions())
                        {
                            spriteSheet.Save(outputPath, pngOptions, region);
                        }

                        frameIndex++;
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
 * 1. When a game developer needs to extract individual 64×64 animation frames from a TGA sprite sheet and save them as PNG files for use in Unity or other game engines.
 * 2. When a UI designer wants to split a large TGA texture atlas into separate 64×64 PNG icons for a mobile app’s toolbar.
 * 3. When a video editor requires each 64×64 frame of a TGA sprite sheet to be exported as PNG images for frame‑by‑frame compositing in After Effects.
 * 4. When a web developer must convert legacy TGA sprite sheets into web‑friendly 64×64 PNG sprites for HTML5 canvas animations.
 * 5. When an automated build pipeline needs to generate 64×64 PNG thumbnails from a TGA sprite sheet for documentation or asset preview generation.
 */