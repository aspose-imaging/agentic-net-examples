using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\animation.apng";
        string outputPath = "Output\\animation.gif";

        try
        {
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
 * 1. When a web developer needs to convert animated PNG (APNG) assets to widely supported GIF files for legacy browsers while embedding a conversion timestamp comment for audit trails.
 * 2. When a mobile app team wants to preprocess user‑uploaded APNG stickers into GIFs to reduce file size and add a date‑time comment for version tracking.
 * 3. When an e‑learning platform automates the generation of animated tutorials, converting APNG slides to GIFs and stamping the conversion date to comply with content management policies.
 * 4. When a digital marketing agency prepares campaign graphics, converting high‑color‑depth APNG banners to GIFs for email newsletters and including a timestamp comment to verify when the assets were produced.
 * 5. When a game developer extracts in‑game APNG animations and converts them to GIFs for documentation, adding a conversion timestamp comment to synchronize with build logs.
 */