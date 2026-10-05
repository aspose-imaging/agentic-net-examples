// HOW-TO: Batch Resize PNG Images to 640x480 and Convert to BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    image.Resize(640, 480);
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".bmp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    BmpOptions options = new BmpOptions();
                    image.Save(outputPath, options);
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
 * 1. When you need to automatically shrink a collection of PNG screenshots to a standard 640x480 size and store them as BMP files for a legacy Windows application.
 * 2. When a photo‑gallery website requires all uploaded PNG pictures to be resized and saved in BMP format for faster thumbnail generation on a .NET server.
 * 3. When migrating assets from a design folder to a format compatible with a printing system that only accepts BMP, while ensuring each image fits a 640x480 layout.
 * 4. When creating a batch script that processes user‑provided PNG icons, resizes them to a uniform resolution, and converts them to BMP for use in a game engine that reads BMP textures.
 * 5. When implementing an automated build step that converts a set of PNG UI mockups into 640x480 BMP files to be bundled with a desktop application built with C#.
 */
