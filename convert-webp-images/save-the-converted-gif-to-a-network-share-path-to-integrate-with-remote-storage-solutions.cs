// HOW-TO: Save GIF As PNG To Network Share Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\animation.gif";
            string outputPath = @"\\Server\Share\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                gif.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert an animated GIF to a static PNG and store the result on a shared network folder for other users to access.
 * 2. When a server‑side application processes uploaded GIF files and saves the converted PNG images to a remote file share for centralized archiving.
 * 3. When integrating Aspose.Imaging into a workflow that generates thumbnails from GIFs and writes them to a network location accessed by multiple services.
 * 4. When automating image conversion in a Windows service that must place the output PNG on a UNC path for downstream reporting tools.
 * 5. When migrating legacy GIF assets to PNG format and saving them directly to a network share to keep the original directory structure intact.
 */
