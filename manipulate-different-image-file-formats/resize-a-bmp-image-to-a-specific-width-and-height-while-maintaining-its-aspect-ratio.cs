using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (BmpImage image = (BmpImage)Image.Load(inputPath))
            {
                int targetWidth = 800;
                int targetHeight = 600;

                double widthRatio = (double)targetWidth / image.Width;
                double heightRatio = (double)targetHeight / image.Height;
                double scale = Math.Min(widthRatio, heightRatio);

                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                BmpOptions options = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, options);
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
 * 1. When a developer needs to generate thumbnail previews of user‑uploaded BMP files for a web gallery while preserving the original aspect ratio.
 * 2. When a desktop application must downscale large BMP scans to fit within a printable area of 800×600 pixels without distortion.
 * 3. When an automated batch‑processing script has to convert high‑resolution BMP assets into smaller versions for faster loading in a mobile game.
 * 4. When a document management system requires resizing BMP images to a standard size before embedding them into PDF reports using C#.
 * 5. When a legacy Windows utility must adjust BMP screenshots to a consistent resolution for archival storage while keeping the image proportions intact.
 */