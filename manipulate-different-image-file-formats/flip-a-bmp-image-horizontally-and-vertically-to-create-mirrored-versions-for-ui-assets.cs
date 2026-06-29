using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input BMP file
            string inputPath = "input.bmp";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Horizontal flip output
            string outputPathHorizontal = "output\\horizontal.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathHorizontal));
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                image.RotateFlip(Aspose.Imaging.RotateFlipType.RotateNoneFlipX);
                image.Save(outputPathHorizontal, new BmpOptions());
            }

            // Vertical flip output
            string outputPathVertical = "output\\vertical.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathVertical));
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                image.RotateFlip(Aspose.Imaging.RotateFlipType.RotateNoneFlipY);
                image.Save(outputPathVertical, new BmpOptions());
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
 * 1. When creating mirrored UI icons for a Windows desktop application, a developer can use this code to generate horizontal and vertical BMP versions automatically.
 * 2. When preparing game sprites that need left‑right or top‑bottom reflections for character animation, the code flips the original BMP and saves the mirrored assets.
 * 3. When building a responsive web interface that swaps images based on layout direction (e.g., RTL languages), the developer can produce flipped BMP files with Aspose.Imaging in C#.
 * 4. When generating printable labels that require a reversed image for embossing or laser engraving, the code provides a quick way to create vertically mirrored BMP files.
 * 5. When maintaining a legacy asset pipeline that stores UI graphics as BMP files, a developer can use this snippet to batch‑process and create flipped copies without manual editing.
 */