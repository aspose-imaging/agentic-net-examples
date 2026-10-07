// HOW-TO: Batch Resize Images to 400px Width and Convert to PNG in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    int newWidth = 400;
                    int newHeight = (int)(image.Height * (newWidth / (double)image.Width));
                    image.Resize(newWidth, newHeight);

                    using (PngOptions options = new PngOptions())
                    {
                        image.Save(outputPath, options);
                    }
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
 * 1. When you need to generate uniformly sized thumbnails for a web gallery from various image formats using C#.
 * 2. When you must prepare product photos for an e‑commerce site by scaling them to a fixed width while keeping aspect ratio and saving as PNG.
 * 3. When you want to automate conversion of a folder of mixed‑format images to PNG for consistent compression and transparency support.
 * 4. When you are building a batch processing tool that resizes user‑uploaded pictures to fit mobile screen width before storage.
 * 5. When you require a simple C# script to resize and re‑encode legacy JPEG or BMP files to a standard 400‑pixel width PNG for archival purposes.
 */
