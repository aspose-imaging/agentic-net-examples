using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputHorizontalPath = "output\\output_horizontal.bmp";
            string outputVerticalPath = "output\\output_vertical.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputHorizontalPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputVerticalPath));

            using (Image horiz = Image.Load(inputPath))
            {
                horiz.RotateFlip(RotateFlipType.RotateNoneFlipX);
                horiz.Save(outputHorizontalPath);
            }

            using (Image vert = Image.Load(inputPath))
            {
                vert.RotateFlip(RotateFlipType.RotateNoneFlipY);
                vert.Save(outputVerticalPath);
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
 * 1. When creating mirrored button icons for a Windows desktop application, a developer can use this code to flip a BMP image horizontally or vertically and save the results as separate UI assets.
 * 2. When generating left‑to‑right and right‑to‑left language versions of a game sprite sheet, the code can produce horizontal and vertical BMP mirrors without manually editing the graphics.
 * 3. When preparing thumbnail previews that need to show both original and flipped orientations for a photo‑management tool, the RotateFlip operations let the developer output mirrored BMP files automatically.
 * 4. When building a responsive UI that swaps image direction based on layout direction (LTR vs RTL), this snippet quickly creates the required horizontal BMP mirror for the alternate layout.
 * 5. When testing image‑processing pipelines that must handle BMP files with different orientations, a developer can use the code to produce controlled horizontal and vertical flips for validation purposes.
 */