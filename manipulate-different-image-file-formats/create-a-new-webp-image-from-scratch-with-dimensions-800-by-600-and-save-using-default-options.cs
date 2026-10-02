// HOW-TO: Create a Blank 800x600 WebP Image and Save in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.webp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            WebPOptions options = new WebPOptions() { Source = source };

            using (RasterImage canvas = (RasterImage)Image.Create(options, 800, 600))
            {
                canvas.Save();
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
 * 1. When you need to generate a placeholder WebP image of a specific size for a web page without loading an existing file.
 * 2. When you want to create a blank canvas to draw graphics programmatically before adding custom drawings or text.
 * 3. When an automated report generator must produce a WebP thumbnail of a fixed dimension as part of its output.
 * 4. When a server‑side service creates empty WebP files to reserve space for later image processing in a pipeline.
 * 5. When testing image‑processing code you require a known‑size WebP file without relying on external assets.
 */
