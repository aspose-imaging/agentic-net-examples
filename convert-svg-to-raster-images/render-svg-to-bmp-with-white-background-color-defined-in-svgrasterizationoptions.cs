// HOW-TO: Render SVG to BMP with White Background Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        string inputPath = "input.svg";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White
                    }
                };

                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to convert vector SVG logos into BMP thumbnails for legacy Windows applications that require a solid white background.
 * 2. When generating BMP assets for printing workflows that only accept raster images and you must ensure a consistent background color.
 * 3. When creating batch image processing pipelines that transform user‑uploaded SVG diagrams into BMP files for storage in a database with a fixed background.
 * 4. When preparing graphics for embedded systems that support only BMP format and need a predictable white canvas behind the SVG content.
 * 5. When automating the conversion of SVG icons to BMP sprites for game development where the background must be explicitly set to white.
 */
