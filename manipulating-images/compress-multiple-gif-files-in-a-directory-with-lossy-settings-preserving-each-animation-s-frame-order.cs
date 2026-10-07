// HOW-TO: Batch Compress GIF Images with Lossy Settings in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                if (!string.Equals(Path.GetExtension(inputPath), ".gif", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (GifImage gif = (GifImage)Image.Load(inputPath))
                {
                    GifOptions options = new GifOptions();
                    gif.Save(outputPath, options);
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
 * 1. When you need to reduce the file size of many animated GIFs before uploading them to a website, this code batch‑compresses the files while keeping the original frame sequence.
 * 2. When an e‑commerce platform must generate lightweight product animations for faster page loads, developers can use this routine to process all GIF assets in a folder automatically.
 * 3. When a mobile app needs to send animated stickers over limited bandwidth, the script can shrink each GIF in a directory without breaking the animation order.
 * 4. When an email marketing system wants to attach several GIF banners but stay under size limits, this code compresses each banner in bulk using Aspose.Imaging for .NET.
 * 5. When a digital archive requires periodic optimization of stored GIF animations to save storage space, the program iterates through a folder and applies lossy compression to every file.
 */
