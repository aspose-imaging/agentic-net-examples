using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to convert animated PNG (APNG) assets into GIFs for compatibility with legacy browsers while preserving the original frame timing via GIF comment extensions.
 * 2. When an e‑commerce platform wants to display product animations on email newsletters that only support GIF, and must embed the APNG frame delay information in the GIF comment to synchronize playback.
 * 3. When a mobile game developer exports character animation sequences from APNG to GIF for use in social media sharing, ensuring the original animation speed is retained through the GIF comment extension.
 * 4. When a content management system automatically processes user‑uploaded APNG stickers and converts them to GIFs for use in chat applications that read frame delay from the GIF comment block.
 * 5. When a digital marketing tool generates animated banners by converting APNG templates to GIFs and embeds the frame delay metadata in the GIF comment to allow downstream tools to adjust animation speed accurately.
 */