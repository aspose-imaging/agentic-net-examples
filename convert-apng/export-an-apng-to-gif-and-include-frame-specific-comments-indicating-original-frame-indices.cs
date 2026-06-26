using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\result.png";

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
                var options = new PngOptions();
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
 * 1. When a developer needs to convert animated PNG (APNG) files to GIF format for legacy browser support while embedding frame‑specific comments that record the original frame indices for later reference.
 * 2. When an e‑learning platform generates GIF previews of APNG tutorial animations and adds comments with original frame numbers to synchronize captions and annotations.
 * 3. When a mobile game developer extracts animation sequences from APNG sprite sheets, saves them as GIFs, and includes frame index comments to simplify debugging of animation timing in C#.
 * 4. When a digital marketing system creates GIF versions of APNG advertisements for email campaigns and stores the original frame indices in comments to track which frame corresponds to each visual element.
 * 5. When an analytics pipeline processes user‑uploaded APNG stickers, converts them to GIFs, and records the original frame indices in comments for statistical analysis of animation usage.
 */