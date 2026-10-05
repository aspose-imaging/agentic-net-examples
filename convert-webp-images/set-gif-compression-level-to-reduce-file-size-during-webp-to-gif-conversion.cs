// HOW-TO: Convert WebP to GIF with Adjustable Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "input.webp");
        string outputPath = Path.Combine("Output", "output.gif");

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                webp.Save(outputPath, gifOptions);
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
 * 1. When you need to shrink animated WebP assets for email attachments by converting them to smaller GIF files in a C# application.
 * 2. When a web service must deliver GIF previews of user‑uploaded WebP images while keeping bandwidth low through compression settings.
 * 3. When an e‑learning platform converts high‑resolution WebP diagrams to GIFs for older browsers and wants to control the output size.
 * 4. When a mobile app generates GIF stickers from WebP sources and must limit file size to meet app store upload limits.
 * 5. When a batch processing script automates conversion of a large WebP gallery to compressed GIFs for archival storage.
 */
