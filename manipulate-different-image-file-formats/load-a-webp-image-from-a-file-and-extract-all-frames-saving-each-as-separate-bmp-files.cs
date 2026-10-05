// HOW-TO: Extract All Frames From a WebP Image and Save As BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputDir = "output_frames";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                WebPImage webp = image as WebPImage;
                if (webp == null)
                {
                    Console.Error.WriteLine("Input is not a WebP image.");
                    return;
                }

                for (int i = 0; i < webp.Pages.Length; i++)
                {
                    RasterImage frame = webp.Pages[i] as RasterImage;
                    if (frame == null)
                        continue;

                    string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");
                    string dir = Path.GetDirectoryName(outputPath);
                    if (string.IsNullOrWhiteSpace(dir))
                        dir = ".";
                    Directory.CreateDirectory(dir);

                    frame.Save(outputPath, new BmpOptions());
                }
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
 * 1. When you need to convert each animation frame of a WebP file into separate BMP files for legacy Windows applications.
 * 2. When you want to preprocess animated WebP assets for a game engine that only supports BMP textures.
 * 3. When you must extract individual frames from a WebP advertisement to generate thumbnails in BMP format.
 * 4. When you are building a batch script that archives every frame of a WebP animation as lossless BMP for quality‑preserving analysis.
 * 5. When you need to read a WebP image on a server, split its pages, and store them as BMP files for downstream image‑processing pipelines.
 */
