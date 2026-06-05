using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\source.bmp";
            string outputHorizontalPath = @"C:\Images\source_horizontal.bmp";
            string outputVerticalPath = @"C:\Images\source_vertical.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputHorizontalPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputVerticalPath));

            // Create horizontal mirrored version
            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                image.Save(outputHorizontalPath);
            }

            // Create vertical mirrored version
            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                image.Save(outputVerticalPath);
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
 * 1. When creating left‑to‑right mirrored icons for a right‑to‑left language UI, a developer can use this C# Aspose.Imaging code to flip a BMP image horizontally and save the mirrored version.
 * 2. When generating vertically flipped button states (e.g., pressed or disabled) for a game UI, the code can load a BMP sprite, apply RotateFlipType.RotateNoneFlipY, and output the new asset.
 * 3. When preparing duplicate BMP assets for a responsive design that requires both normal and mirrored versions of a logo, the snippet automates horizontal and vertical flipping in .NET.
 * 4. When a developer needs to batch‑process legacy BMP resources to create mirrored toolbar icons without manual editing, this example shows how to verify file existence, create output folders, and save flipped images using Aspose.Imaging.
 * 5. When implementing a custom image‑processing pipeline that must produce mirrored BMP textures for 2‑D side‑scroller games, the code demonstrates loading, rotating, and saving the images with RotateFlipType in C#.
 */