// HOW-TO: Save PNG Image With Alpha Channel To Output Folder In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/processed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
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
 * 1. When you need to preserve transparency while saving a processed PNG to a specific directory using Aspose.Imaging in a C# application.
 * 2. When an automated batch job must convert input PNG files to true‑color with alpha and store the results in an organized output folder.
 * 3. When a web service generates PNG thumbnails with RGBA data and must write them to a server‑side path without losing the alpha channel.
 * 4. When a desktop utility loads a user‑selected PNG, applies image options, and saves the modified file to a subfolder for later use.
 * 5. When a CI/CD pipeline validates image assets by loading them, setting the color type, and exporting the final PNG to a build output directory.
 */
