// HOW-TO: Flip BMP Image Horizontally and Vertically Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPathHorizontal = "output_horizontal.bmp";
            string outputPathVertical = "output_vertical.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Horizontal flip
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPathHorizontal) ?? ".");
                BmpOptions bmpOptions = new BmpOptions();
                image.Save(outputPathHorizontal, bmpOptions);
            }

            // Vertical flip
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPathVertical) ?? ".");
                BmpOptions bmpOptions = new BmpOptions();
                image.Save(outputPathVertical, bmpOptions);
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
 * 1. When you need mirrored button icons for a Windows desktop UI, you can flip a BMP file horizontally with Aspose.Imaging in C#.
 * 2. When creating a vertically reflected background image for a game level, the code generates a flipped BMP version programmatically.
 * 3. When preparing opposite‑direction sprite sheets for a 2‑D animation, you can use this routine to produce a vertically flipped BMP copy.
 * 4. When an application requires both left‑to‑right and top‑to‑bottom mirrored versions of a bitmap logo for responsive layouts, the example automates the process.
 * 5. When automating asset pipelines that store graphics as BMP, this snippet quickly creates horizontal and vertical mirrors without manual editing.
 */
