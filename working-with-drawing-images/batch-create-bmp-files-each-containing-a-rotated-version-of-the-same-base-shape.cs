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
            // Output directory for all BMP files
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            // Base image dimensions
            int width = 200;
            int height = 200;

            // Path for the base image (drawn once, then reused)
            string basePath = Path.Combine(outputDir, "base.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(basePath));

            // Create base BMP image and draw a simple rectangle shape
            BmpOptions baseOptions = new BmpOptions();
            baseOptions.BitsPerPixel = 24;
            baseOptions.Source = new FileCreateSource(basePath, false);
            using (Image baseImage = Image.Create(baseOptions, width, height))
            {
                Graphics graphics = new Graphics(baseImage);
                graphics.Clear(Color.White);
                graphics.DrawRectangle(new Pen(Color.Blue, 3), new Rectangle(50, 50, 100, 100));
                // Save the created image (output is already bound via FileCreateSource)
                baseImage.Save();
            }

            // Verify that the base image was created before loading it
            if (!File.Exists(basePath))
            {
                Console.Error.WriteLine($"File not found: {basePath}");
                return;
            }

            // Define the set of rotations to apply
            RotateFlipType[] rotations = new RotateFlipType[]
            {
                RotateFlipType.Rotate90FlipNone,
                RotateFlipType.Rotate180FlipNone,
                RotateFlipType.Rotate270FlipNone,
                RotateFlipType.RotateNoneFlipX,
                RotateFlipType.RotateNoneFlipY,
                RotateFlipType.Rotate90FlipX
            };

            // Process each rotation, create a new BMP file
            foreach (RotateFlipType rot in rotations)
            {
                string outPath = Path.Combine(outputDir, $"rotated_{rot}.bmp");
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                // Load the base image (input)
                if (!File.Exists(basePath))
                {
                    Console.Error.WriteLine($"File not found: {basePath}");
                    return;
                }

                using (Image img = Image.Load(basePath))
                {
                    // Apply rotation/flip
                    img.RotateFlip(rot);

                    // Save the rotated image to a new BMP file
                    BmpOptions saveOptions = new BmpOptions();
                    saveOptions.BitsPerPixel = 24;
                    saveOptions.Source = new FileCreateSource(outPath, false);
                    img.Save(outPath, saveOptions);
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
 * 1. When generating a set of sprite sheets for a 2‑D game engine, a developer can use this code to create BMP files of a base shape rotated at different angles for animation frames.
 * 2. When preparing test data for image‑processing algorithms that must handle various orientations, the code can batch‑produce BMP images with systematic rotations to validate rotation detection logic.
 * 3. When producing printable labels or icons that need to be displayed in portrait and landscape modes, a developer can quickly generate BMP files with the required flipped and rotated versions.
 * 4. When creating a catalog of product thumbnails that must appear correctly after user‑driven rotation, the code can pre‑render BMP images at common angles to improve UI responsiveness.
 * 5. When building a machine‑learning dataset for shape‑recognition models, the code can generate multiple BMP samples of the same rectangle shape rotated and flipped to increase training diversity.
 */