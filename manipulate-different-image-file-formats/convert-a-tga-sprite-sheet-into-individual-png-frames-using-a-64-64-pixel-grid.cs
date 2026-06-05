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
            string inputPath = "sprite_sheet.tga";
            string outputDirectory = "Frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            using (RasterImage spriteSheet = (RasterImage)Image.Load(inputPath))
            {
                int frameWidth = 64;
                int frameHeight = 64;
                int columns = spriteSheet.Width / frameWidth;
                int rows = spriteSheet.Height / frameHeight;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"frame_{row}_{col}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Define the region to extract
                        Rectangle sourceRect = new Rectangle(col * frameWidth, row * frameHeight, frameWidth, frameHeight);
                        // Load pixel data from the sprite sheet
                        int[] pixels = spriteSheet.LoadArgb32Pixels(sourceRect);

                        // Create a new PNG image bound to the output file
                        PngOptions options = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };

                        using (RasterImage frameImage = (RasterImage)Image.Create(options, frameWidth, frameHeight))
                        {
                            // Write pixel data to the new image
                            frameImage.SaveArgb32Pixels(new Rectangle(0, 0, frameWidth, frameHeight), pixels);
                            // Since the image is bound to a file, call Save()
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
 * 1. When a game developer needs to convert a TGA sprite sheet into individual 64 × 64 PNG frames for use in a Unity or Unreal Engine animation pipeline, this code extracts each cell and saves it as a separate PNG file.
 * 2. When a UI/UX designer provides assets as a large TGA sprite sheet and a web developer must generate separate 64 × 64 PNG icons for responsive web pages, this snippet automates the extraction.
 * 3. When a mobile app team wants to pre‑process a TGA sprite atlas into discrete PNG textures to reduce runtime memory usage on iOS or Android, the code creates the required frames programmatically.
 * 4. When a data‑visualization tool needs to import individual frames from a TGA sprite sheet for frame‑by‑frame playback in a C# WPF application, this example shows how to load, crop, and write PNG images with Aspose.Imaging.
 * 5. When an automated build system must batch‑convert legacy TGA sprite sheets into PNG assets for version control or CI/CD pipelines, the code provides a repeatable C# solution using RasterImage and PngOptions.
 */