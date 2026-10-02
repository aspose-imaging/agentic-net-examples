// HOW-TO: Set White Background When Converting SVG to BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = "input.svg";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();
                rasterizationOptions.BackgroundColor = Color.White;

                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.VectorRasterizationOptions = rasterizationOptions;

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
 * 1. When you need to render an SVG with a solid white canvas before exporting it as a BMP for Windows applications.
 * 2. When generating thumbnails of vector graphics for reports that require a non‑transparent background in bitmap format.
 * 3. When converting SVG logos to BMP icons to ensure the background matches a white UI theme.
 * 4. When processing user‑uploaded SVG files on a server and saving them as BMPs without preserving transparency.
 * 5. When creating print‑ready bitmap images from SVG diagrams where a white background is required for accurate color reproduction.
 */
