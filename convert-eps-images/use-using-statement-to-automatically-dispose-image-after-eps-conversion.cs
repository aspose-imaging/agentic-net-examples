// HOW-TO: Convert EPS to Grayscale PNG and SVG with Automatic Disposal in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.eps";
            string outputPngPath = "output\\output.png";
            string outputSvgPath = "output\\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

            using var image = Image.Load(inputPath);

            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.Grayscale
            };
            image.Save(outputPngPath, pngOptions);

            var svgOptions = new SvgOptions();
            image.Save(outputSvgPath, svgOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a grayscale PNG preview and an editable SVG from a vector EPS file in a C# application while ensuring the image resources are released automatically.
 * 2. When building a document conversion service that transforms uploaded EPS artwork into web‑friendly PNG and SVG formats without leaking memory.
 * 3. When creating a desktop tool that batch‑processes EPS files into grayscale PNG thumbnails and scalable SVG copies, using the using statement to manage the Image object lifecycle.
 * 4. When integrating Aspose.Imaging into a CI pipeline to validate EPS assets by converting them to PNG and SVG for visual regression testing, with automatic disposal of the loaded image.
 * 5. When developing a server‑side API that accepts EPS uploads and returns both a grayscale PNG for quick display and an SVG for further editing, leveraging C#'s using syntax to handle resource cleanup.
 */
