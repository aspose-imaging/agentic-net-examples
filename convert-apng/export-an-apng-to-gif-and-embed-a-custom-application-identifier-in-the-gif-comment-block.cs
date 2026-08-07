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
            string inputPath = "input.apng";
            string outputPath = "output/output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                GifOptions options = new GifOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to convert animated PNG (APNG) files into GIF format to ensure compatibility with legacy browsers while preserving the animation frames.
 * 2. When an application must embed a custom application identifier in the GIF comment block for tracking the source tool that generated the image.
 * 3. When a game studio batch‑processes sprite animations stored as APNGs into GIFs that can be displayed on older consoles supporting only GIF animation.
 * 4. When a marketing platform automatically creates shareable GIFs from user‑uploaded APNGs and adds a brand‑specific comment tag for proper attribution.
 * 5. When an e‑learning system converts instructional APNG diagrams to GIFs for email delivery and includes a version code in the GIF comment to manage content updates.
 */