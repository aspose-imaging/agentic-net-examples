// HOW-TO: Rotate PNG Image 45 Degrees with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 200;
            int height = 200;

            using (PngImage png = new PngImage(width, height, PngColorType.TruecolorWithAlpha))
            {
                int[] transparentPixels = new int[width * height];
                png.SaveArgb32Pixels(new Rectangle(0, 0, width, height), transparentPixels);

                png.Rotate(45f, false, Color.Transparent);

                if (png.Width != width || png.Height != height)
                {
                    Console.WriteLine($"Dimensions changed: {png.Width}x{png.Height}");
                }
                else
                {
                    Console.WriteLine($"Dimensions unchanged: {png.Width}x{png.Height}");
                }

                png.Save(outputPath);
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
 * 1. When you need to generate a blank PNG canvas, rotate it at an angle while keeping the original width and height for UI overlays.
 * 2. When creating thumbnails that must stay the same size after a 45‑degree tilt, using Aspose.Imaging to preserve transparent corners.
 * 3. When preparing graphics for a game sprite sheet where the image is rotated but the layout grid dimensions cannot change.
 * 4. When processing scanned documents that require a diagonal orientation without altering the page dimensions, ensuring compatibility with existing layout engines.
 * 5. When building a web service that returns a rotated PNG with a transparent background while confirming the output size matches the input for downstream processing.
 */
