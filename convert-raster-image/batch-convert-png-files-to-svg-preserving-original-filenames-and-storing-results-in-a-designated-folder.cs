// HOW-TO: Batch Convert PNG Images to SVG Files with Original Filenames in C# (Aspose.Imaging for .NET)
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
            string inputFolder = "input";
            string outputFolder = "output";

            Directory.CreateDirectory(outputFolder);

            var pngFiles = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly);
            foreach (var inputPath in pngFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".svg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var image = Image.Load(inputPath))
                {
                    var options = new SvgOptions();
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
 * 1. When you need to transform a collection of PNG icons into scalable SVG graphics for responsive web design while keeping each file’s original name.
 * 2. When an automated build process must generate vector versions of product screenshots stored in a folder for documentation purposes.
 * 3. When a migration script has to replace raster logos with SVG equivalents across multiple marketing assets without manual renaming.
 * 4. When a desktop application requires on‑the‑fly conversion of user‑uploaded PNG files to SVG for further editing in vector editors.
 * 5. When a CI pipeline should validate that all PNG assets in a repository can be batch‑converted to SVG and saved to a designated output directory.
 */
