// HOW-TO: Convert OTG to 8‑Bit BMP to Reduce File Size in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (BmpOptions options = new BmpOptions())
                {
                    options.BitsPerPixel = 8;
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
 * 1. When integrating legacy graphics from OTG files into a Windows application that only supports BMP, you need a small‑size output.
 * 2. When preparing images for embedded systems or low‑memory devices, converting OTG to an 8‑bit BMP minimizes storage requirements.
 * 3. When batch‑processing scanned engineering drawings saved as OTG to BMP for compatibility with older CAD tools, a reduced‑color palette speeds up handling.
 * 4. When generating thumbnails for a web gallery that must be BMP format, using an 8‑bit palette keeps the files lightweight.
 * 5. When converting OTG assets for a game that uses BMP textures and requires a limited color palette to improve loading speed.
 */
