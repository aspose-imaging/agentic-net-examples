using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new ApngOptions());
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
 * 1. When a mobile app needs to replace the original colors of an animated WEBP logo with brand‑specific hues before serving it as an APNG for cross‑browser compatibility.
 * 2. When an e‑learning platform wants to convert animated WEBP tutorials into APNG format while applying a custom palette to match the course theme.
 * 3. When a game developer must recolor sprite animations stored in animated WEBP files and export them as APNGs for use in Unity’s UI system.
 * 4. When a marketing website requires animated product demos originally in WEBP to be recolored for seasonal campaigns and delivered as APNGs to support older browsers.
 * 5. When a digital publishing tool needs to ingest animated WEBP assets, adjust their color palette for accessibility standards, and save the result as APNG for inclusion in EPUB files.
 */