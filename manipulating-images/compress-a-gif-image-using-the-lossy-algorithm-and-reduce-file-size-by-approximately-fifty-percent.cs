// HOW-TO: Compress GIF Image With Lossy Algorithm In C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\input.gif";
            string outputPath = "Output\\output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
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
 * 1. When you need to shrink large animated GIFs for faster web page loading without losing visual quality.
 * 2. When you want to reduce the size of GIF assets before sending them in email attachments to stay under size limits.
 * 3. When you are preparing GIFs for mobile apps where bandwidth and storage are limited.
 * 4. When you need to batch‑process GIF files on a server to lower CDN storage costs.
 * 5. When you want to automate GIF compression in a C# build pipeline using Aspose.Imaging.
 */
