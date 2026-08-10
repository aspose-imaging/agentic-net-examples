// HOW-TO: Convert SVG to BMP With Custom Width And Height In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output\\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgImage = image as Aspose.Imaging.FileFormats.Svg.SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an SVG.");
                    return;
                }

                int newWidth = 800;
                int newHeight = 600;

                svgImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                BmpOptions bmpOptions = new BmpOptions();
                svgImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate a bitmap thumbnail of an SVG logo at a specific size for a Windows desktop application.
 * 2. When a reporting tool requires BMP images of vector graphics with exact pixel dimensions for legacy printer compatibility.
 * 3. When an automated batch process must convert scalable SVG diagrams into fixed‑size BMP files for inclusion in PDF documents.
 * 4. When a game engine only accepts BMP textures, and you must resize SVG assets to match the engine’s resolution constraints.
 * 5. When migrating web‑based SVG assets to a Windows service that stores images as BMP files with predefined width and height.
 */
