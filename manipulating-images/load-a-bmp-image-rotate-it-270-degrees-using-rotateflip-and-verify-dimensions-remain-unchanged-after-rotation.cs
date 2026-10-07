// HOW-TO: Rotate BMP Image 270 Degrees with Aspose.Imaging and Keep Dimensions (Aspose.Imaging for .NET)
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
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Store original dimensions
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Rotate 270 degrees without flip
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);

                // Verify dimensions unchanged
                if (image.Width == originalWidth && image.Height == originalHeight)
                {
                    Console.WriteLine("Dimensions unchanged after rotation.");
                }
                else
                {
                    Console.WriteLine($"Dimensions changed: original ({originalWidth}x{originalHeight}) -> rotated ({image.Width}x{image.Height})");
                }

                // Save the rotated image
                image.Save(outputPath);
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
 * 1. When you need to display a BMP graphic that was saved in portrait orientation but must appear rotated 270° in a Windows application without altering its original width and height.
 * 2. When a batch job processes scanned BMP documents and must rotate each page 270 degrees while preserving layout dimensions for downstream PDF conversion.
 * 3. When integrating legacy BMP assets into a game engine that expects images rotated 270° but requires the same pixel dimensions for texture mapping.
 * 4. When an automated reporting system rotates BMP charts 270° for printing on landscape paper while keeping the chart size unchanged.
 * 5. When a photo‑editing tool offers a “rotate left” feature for BMP files and needs to verify that the image dimensions stay consistent after the operation.
 */
