using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access the Rotate overload with background color
                RasterImage raster = (RasterImage)image;

                // Rotate by an arbitrary angle (e.g., 45 degrees) with proportional resizing
                // and a transparent background for empty areas
                float angle = 45f;               // change as needed
                bool resizeProportionally = true;
                raster.Rotate(angle, resizeProportionally, Color.Transparent);

                // Save the rotated image as BMP with transparency support (Bitfields compression)
                var bmpOptions = new BmpOptions
                {
                    Compression = BitmapCompression.Bitfields
                };
                raster.Save(outputPath, bmpOptions);
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
 * 1. When creating a custom map editor that uses Aspose.Imaging for .NET to rotate BMP terrain tiles and needs the empty corners filled with a transparent background for seamless layering.
 * 2. When generating printable product labels where an Aspose.Imaging‑based C# routine rotates a BMP logo to a diagonal orientation while preserving transparency to avoid white margins.
 * 3. When developing a game asset pipeline that employs Aspose.Imaging to rotate sprite sheets stored as BMP files and requires transparent padding so the sprites align correctly after rotation.
 * 4. When building an automated document‑scanning workflow that uses Aspose.Imaging for .NET to correct the orientation of scanned BMP images and fills the newly created corners with transparency for downstream PDF composition.
 * 5. When implementing a batch image‑processing tool in C# that reorients BMP screenshots from legacy software using Aspose.Imaging, applying a transparent background to maintain visual consistency when overlaying them on modern UI mockups.
 */