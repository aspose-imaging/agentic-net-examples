// HOW-TO: Batch Resize PNG Images to 640x480 and Convert to BMP in C# (Aspose.Imaging for .NET)
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

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".bmp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Resize(640, 480);
                    image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to generate low‑resolution BMP thumbnails from a collection of high‑resolution PNG assets for a legacy Windows application.
 * 2. When an automated pipeline must convert user‑uploaded PNG screenshots to 640×480 BMP files for consistent display on embedded devices.
 * 3. When a game development tool requires all texture files in BMP format at a fixed size, and you have a folder of PNG source images.
 * 4. When a reporting system expects BMP images of a specific resolution, and you must batch‑process existing PNG charts before publishing.
 * 5. When migrating a photo archive to a format supported by older printing hardware, you need to resize each PNG to 640×480 and save it as BMP using C#.
 */
