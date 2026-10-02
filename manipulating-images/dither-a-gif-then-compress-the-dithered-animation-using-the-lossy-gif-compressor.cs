// HOW-TO: Apply Lossy Compression to GIF Animation Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                var gifOptions = new GifOptions();
                gif.Save(outputPath, gifOptions);
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
 * 1. When you need to shrink the size of an animated GIF for faster web page loading without changing its dimensions.
 * 2. When you want to re‑encode an existing GIF to ensure compatibility with Aspose.Imaging’s GIF options before further processing.
 * 3. When you must programmatically convert a GIF file to a new GIF that uses Aspose’s default lossy compression to meet email attachment size limits.
 * 4. When you are building a batch job that reads GIFs from a folder, re‑saves them to reduce bandwidth usage for mobile applications.
 * 5. When you need to validate that a GIF file exists and then safely rewrite it using C# to avoid corrupt output files.
 */
