// HOW-TO: Generate Multiple Rotated BMP Images from a Base Shape in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output directory for all generated BMP files
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            // Path for the base image containing the original shape
            string basePath = Path.Combine(outputDir, "base.bmp");

            // Create a BMP image with a simple rectangle shape
            var bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(basePath, false);
            using (Aspose.Imaging.Image baseImage = Aspose.Imaging.Image.Create(bmpOptions, 200, 200))
            {
                var graphics = new Aspose.Imaging.Graphics(baseImage);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawRectangle(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                    new Aspose.Imaging.Rectangle(50, 50, 100, 100));
                // Image is bound to the file source; just call Save()
                baseImage.Save();
            }

            // Verify the base image was created before loading it
            if (!File.Exists(basePath))
            {
                Console.Error.WriteLine($"File not found: {basePath}");
                return;
            }

            // Define the set of rotations to apply
            var rotations = new[]
            {
                Aspose.Imaging.RotateFlipType.Rotate90FlipNone,
                Aspose.Imaging.RotateFlipType.Rotate180FlipNone,
                Aspose.Imaging.RotateFlipType.Rotate270FlipNone,
                Aspose.Imaging.RotateFlipType.RotateNoneFlipX,
                Aspose.Imaging.RotateFlipType.RotateNoneFlipY
            };

            // Generate a rotated BMP for each rotation type
            foreach (var rot in rotations)
            {
                string outPath = Path.Combine(outputDir, $"rotated_{rot}.bmp");
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                // Load the base image, apply rotation, and save
                using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(basePath))
                {
                    img.RotateFlip(rot);
                    img.Save(outPath, new BmpOptions());
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
 * 1. When you need to create a set of BMP icons that show a logo at different angles for a UI theme.
 * 2. When you want to pre‑rotate a graphic for printing on labels that require 90°, 180°, and 270° orientations.
 * 3. When a game engine requires separate sprite sheets for each rotation of a character’s silhouette stored as BMP files.
 * 4. When an automated testing suite must verify image‑processing algorithms using known rotated reference BMPs.
 * 5. When a document generation system must embed the same diagram in several pages, each rotated differently, without performing runtime transformations.
 */
