using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Rotate the image by an arbitrary angle (e.g., 45 degrees)
                // Resize proportionally to fit the rotated content
                // Fill empty areas with a transparent background
                float angle = 45f;
                bool resizeProportionally = true;
                Color transparent = Color.FromArgb(0, 0, 0, 0);
                image.Rotate(angle, resizeProportionally, transparent);

                // Save the rotated image preserving alpha channel
                BmpOptions options = new BmpOptions
                {
                    Compression = BitmapCompression.Bitfields
                };
                image.Save(outputPath, options);
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
 * 1. When a developer needs to generate rotated thumbnails of legacy BMP assets for a Windows desktop application while preserving transparency for overlay UI elements.
 * 2. When an image processing pipeline must align scanned BMP diagrams at arbitrary angles before performing OCR, using Aspose.Imaging’s Rotate method with a transparent background to avoid unwanted white corners.
 * 3. When a game developer wants to rotate sprite sheets stored as BMP files at runtime in C# and keep the empty space transparent so the sprites blend correctly with the game scene.
 * 4. When a reporting tool has to re‑orient BMP charts that were exported in landscape mode to portrait orientation, requiring proportional resizing and a transparent fill to maintain layout consistency.
 * 5. When a batch conversion utility must correct the orientation of user‑uploaded BMP logos by rotating them by a custom angle and saving the result with an alpha channel so the logos can be placed on any background without visible borders.
 */