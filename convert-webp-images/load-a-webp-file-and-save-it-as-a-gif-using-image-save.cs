// HOW-TO: Convert WebP to GIF Using Aspose.Imaging Image.Save in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace WebPToGifConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.webp";
                string outputPath = "output.gif";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    image.Save(outputPath, new GifOptions());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a WebP picture on a legacy website that only supports GIF format.
 * 2. When you are generating email attachments and must convert WebP assets to GIF for compatibility with older email clients.
 * 3. When you are building a batch conversion tool that transforms user‑uploaded WebP files into GIFs for use in social media posts.
 * 4. When you need to embed a small animation in a Windows Forms application that only accepts GIF images.
 * 5. When you are preparing image assets for a game engine that does not recognize WebP and requires GIF sprites.
 */
