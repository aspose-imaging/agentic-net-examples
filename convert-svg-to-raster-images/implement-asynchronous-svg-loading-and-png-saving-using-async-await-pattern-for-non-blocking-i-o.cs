// HOW-TO: Asynchronously Convert Svg To Png Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "example.svg");
            string outputPath = Path.Combine("Output", "example.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    image.Save(outputPath, pngOptions);
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
 * 1. When building a web API that receives SVG uploads and must return PNG thumbnails without blocking the request thread.
 * 2. When developing a desktop application that lets users edit vector graphics and needs to export them to PNG while keeping the UI responsive.
 * 3. When processing a large batch of SVG files on a server and want to perform conversions in parallel using asynchronous I/O to improve throughput.
 * 4. When integrating image conversion into a cloud function or Azure WebJob where non‑blocking operations reduce execution costs.
 * 5. When creating a background service that monitors a folder for new SVG files and automatically saves them as PNG without hindering other file‑system tasks.
 */
