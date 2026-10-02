// HOW-TO: Resize BMP Image to Fit Within Width and Height in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        string inputPath = "input.bmp";
        string outputPath = "output\\resized.bmp";
        int targetWidth = 200;
        int targetHeight = 200;

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
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                float widthRatio = (float)targetWidth / originalWidth;
                float heightRatio = (float)targetHeight / originalHeight;
                float scale = Math.Min(widthRatio, heightRatio);

                int newWidth = (int)(originalWidth * scale);
                int newHeight = (int)(originalHeight * scale);

                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
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
 * 1. When a developer needs to generate thumbnail previews of BMP files for a web gallery while preserving the original aspect ratio.
 * 2. When an application must downscale large BMP scans to a fixed size for faster uploading to a cloud service.
 * 3. When a Windows desktop tool converts user‑uploaded BMP screenshots into a standard 200 × 200 pixel format for consistent UI layout.
 * 4. When a batch‑processing script resizes BMP assets to fit within a specific width and height before embedding them in a PDF report.
 * 5. When a game engine loads BMP textures and requires them to be resized to a target resolution without distortion.
 */
