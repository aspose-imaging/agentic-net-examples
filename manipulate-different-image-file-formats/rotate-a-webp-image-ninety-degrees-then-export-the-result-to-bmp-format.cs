// HOW-TO: Rotate a WebP Image 90 Degrees and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.webp";
        string outputPath = "Output\\rotated.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to display a WebP graphic in a legacy Windows application that only supports BMP, you can rotate it and convert it with this code.
 * 2. When preparing product screenshots captured as WebP for printing, rotating them to portrait orientation and saving as BMP ensures compatibility with print‑ready workflows.
 * 3. When a mobile app uploads WebP photos that must be reoriented and stored on a server that archives images in BMP format, this snippet handles the transformation.
 * 4. When automating batch processing of WebP assets to match a specific layout direction before feeding them into a machine‑vision system that reads BMP files, you can use this routine.
 * 5. When integrating Aspose.Imaging into a .NET service that receives WebP images from users and needs to rotate them 90° for correct viewing on desktop clients that only support BMP, this code provides the solution.
 */
