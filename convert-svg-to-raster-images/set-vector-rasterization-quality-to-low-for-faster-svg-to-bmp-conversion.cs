// HOW-TO: Convert SVG to BMP with Low Quality Rasterization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.svg");
            string outputPath = Path.Combine("Output", "sample.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    bmpOptions.VectorRasterizationOptions = rasterOptions;
                    image.Save(outputPath, bmpOptions);
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
 * 1. When you need to quickly generate BMP previews from SVG icons for a desktop application where rendering speed is more important than visual fidelity.
 * 2. When a server‑side C# service must batch‑convert large numbers of SVG diagrams to BMP files and wants to reduce CPU usage by lowering rasterization quality.
 * 3. When exporting SVG charts to BMP for legacy reporting tools that only accept bitmap images, and you prefer a faster conversion at the cost of some detail.
 * 4. When creating low‑resolution thumbnails of vector graphics for a web gallery using Aspose.Imaging, and you want the conversion to complete in milliseconds.
 * 5. When integrating SVG assets into a game engine that requires BMP textures and you need a simple C# routine that trades image sharpness for quicker load times.
 */
