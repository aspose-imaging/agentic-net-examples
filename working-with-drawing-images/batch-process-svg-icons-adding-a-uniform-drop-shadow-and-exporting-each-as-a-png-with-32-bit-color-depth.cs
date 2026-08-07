using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputPngs";

            Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a large collection of SVG icons stored in a folder into high‑quality 32‑bit PNG files for use in a web application, they can use this batch conversion code.
 * 2. When an automated build pipeline must generate raster PNG assets from source SVG graphics to ensure compatibility with legacy browsers, the script can process all files in one step.
 * 3. When a design team exports vector icons from a design tool and wants a quick C# utility to create PNG thumbnails for documentation or UI mockups, this code handles the folder‑to‑folder conversion.
 * 4. When a desktop application requires runtime conversion of user‑provided SVG files into PNG images for printing or PDF embedding, the loop can load each SVG and save it as a PNG on demand.
 * 5. When a CI/CD process needs to validate that every SVG asset in a repository can be successfully rasterized without errors, the try‑catch block logs missing or corrupt files while converting them to PNG.
 */