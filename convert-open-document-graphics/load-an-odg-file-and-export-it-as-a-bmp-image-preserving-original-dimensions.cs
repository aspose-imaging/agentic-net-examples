// HOW-TO: Convert ODG to BMP with Original Size Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output\\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                BmpOptions options = new BmpOptions();
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
 * 1. When a desktop application needs to display OpenDocument graphics as BMP thumbnails while keeping the original dimensions.
 * 2. When a batch‑processing service converts user‑uploaded ODG files to BMP for compatibility with legacy Windows imaging tools.
 * 3. When an automated report generator embeds ODG diagrams into a BMP‑based PDF template that requires exact pixel size.
 * 4. When a migration script transforms ODG assets from an old document management system into BMP files for a new .NET‑based archive.
 * 5. When a game engine imports ODG artwork as BMP textures and must preserve the original resolution for accurate rendering.
 */
