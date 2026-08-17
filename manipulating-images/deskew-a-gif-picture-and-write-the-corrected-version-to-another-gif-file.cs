// HOW-TO: How To Deskew A GIF Image And Save As New GIF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output\\deskewed.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (GifImage image = (GifImage)Image.Load(inputPath))
            {
                // Deskew the image without resizing, using a light gray background
                image.NormalizeAngle(false, Color.LightGray);

                // Save the corrected image as GIF
                image.Save(outputPath, new GifOptions());
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
 * 1. When you receive scanned animated GIFs that are slightly rotated and need to be straightened before displaying on a website.
 * 2. When an automated batch job must correct the orientation of user‑uploaded GIF stickers without changing their dimensions.
 * 3. When you want to preprocess GIF frames for OCR or computer‑vision pipelines by removing skew while preserving the original palette.
 * 4. When a legacy system stores screenshots as GIFs with a gray background and you need to normalize their angle for consistent reporting.
 * 5. When creating a thumbnail generator that first deskews each GIF to ensure the thumbnail shows the image upright.
 */
