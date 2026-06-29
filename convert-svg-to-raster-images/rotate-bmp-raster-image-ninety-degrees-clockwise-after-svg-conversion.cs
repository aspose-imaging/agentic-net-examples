using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save as BMP using default BMP options
                BmpOptions bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to convert an SVG logo to a BMP thumbnail and rotate it 90° clockwise for display in a legacy Windows application.
 * 2. When an automated build script must generate right‑oriented BMP assets from vector SVG icons for inclusion in a game’s sprite sheet.
 * 3. When a batch‑processing tool has to re‑orient scanned SVG diagrams and save them as BMP files for compatibility with older reporting software.
 * 4. When a web service receives SVG diagrams, rotates them to match user‑specified orientation, and returns BMP images for download on devices that only support raster formats.
 * 5. When a desktop utility must ensure that converted BMP images from SVG files are correctly rotated for printing on a printer that expects a clockwise orientation.
 */