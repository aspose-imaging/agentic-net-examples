// HOW-TO: Create BMP Thumbnails with Black Border Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputImages";
            string outputDirectory = "Thumbnails";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            var bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");
            foreach (var inputPath in bmpFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + "_thumb.bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    image.Resize(100, 100);

                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.DrawRectangle(
                        new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1),
                        0, 0, image.Width, image.Height);

                    BmpOptions options = new BmpOptions();
                    options.Source = new FileCreateSource(outputPath, false);
                    image.Save(outputPath, options);
                }
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
 * 1. When you need to generate small preview images of a large collection of BMP files for a file‑explorer UI, and you want each preview to have a consistent thin border.
 * 2. When an automated reporting system must produce 100 × 100 pixel thumbnails of scanned BMP documents and visually separate them with a black frame for better readability.
 * 3. When a desktop application processes user‑uploaded BMP graphics in bulk, resizes them to uniform dimensions, and adds a border to maintain a consistent layout in a gallery view.
 * 4. When you are preparing assets for a game or simulation that requires fixed‑size BMP sprites with a visible edge outline to avoid blending with the background.
 * 5. When a migration script converts legacy BMP assets to thumbnail versions while preserving the original format and adding a border to indicate they are low‑resolution placeholders.
 */
