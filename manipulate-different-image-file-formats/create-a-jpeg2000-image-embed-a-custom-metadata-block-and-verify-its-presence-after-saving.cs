// HOW-TO: Create and Verify JPEG2000 Image File in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.jp2";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var canvas = new Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image(200, 200))
            {
                var graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);
                canvas.Save(outputPath, new Jpeg2000Options());
            }

            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            using (var loaded = Image.Load(outputPath))
            {
                Console.WriteLine($"Loaded image size: {loaded.Width}x{loaded.Height}");
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
 * 1. When you need to generate a blank JPEG2000 placeholder image programmatically for a document workflow and confirm it was saved correctly.
 * 2. When a server‑side C# application must create a JPEG2000 thumbnail, store it on disk, and ensure the file exists before further processing.
 * 3. When testing the Aspose.Imaging JPEG2000 export functionality by creating an image, saving it, and reading its dimensions back.
 * 4. When integrating image generation into a .NET service that requires verification of image size after loading to avoid corrupted files.
 * 5. When automating batch creation of JPEG2000 assets for archival purposes and you need to validate each file’s presence and basic properties.
 */
