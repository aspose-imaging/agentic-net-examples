// HOW-TO: Convert PNG to Transparent SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.BackgroundColor = Color.Transparent;
                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to embed a PNG logo into a web page as a scalable SVG without any background color.
 * 2. When you are generating vector assets from user‑uploaded raster images for responsive design and require a transparent background.
 * 3. When an e‑commerce platform must convert product photos to SVG format for high‑resolution printing while preserving transparency.
 * 4. When a desktop application creates diagram exports and must replace bitmap icons with transparent SVG equivalents for better scaling.
 * 5. When an automated build pipeline processes assets and needs to batch‑convert PNG files to SVG with no background using C# and Aspose.Imaging.
 */
