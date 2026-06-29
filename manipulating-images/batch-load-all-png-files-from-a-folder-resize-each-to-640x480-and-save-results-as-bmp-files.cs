using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached) image.CacheData();
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
 * 1. When a developer needs to convert a large collection of PNG screenshots into BMP format for legacy Windows applications that only accept BMP files.
 * 2. When an automated build pipeline must generate uniformly sized 640x480 thumbnails from user‑uploaded PNG assets before packaging them into a desktop installer.
 * 3. When a photo‑management tool has to batch‑process PNG images from a folder, resize them to a standard resolution, and store the results as BMP files for faster rendering on low‑power devices.
 * 4. When a migration script must read PNG files, ensure they are cached in memory, resize them, and save them as BMP to meet a third‑party vendor’s image specifications.
 * 5. When a C# console utility is required to scan an input directory, resize each PNG to 640x480, and output BMP files to an output directory for bulk image preprocessing in a scientific imaging workflow.
 */