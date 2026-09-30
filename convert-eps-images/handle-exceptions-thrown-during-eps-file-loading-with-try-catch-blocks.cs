// HOW-TO: Load EPS and Convert to PNG and SVG with C# Error Handling (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        const string inputPath = "input.eps";
        const string outputPngPath = "output\\output.png";
        const string outputSvgPath = "output\\output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Image image;
            try
            {
                image = Image.Load(inputPath);
            }
            catch (Exception loadEx)
            {
                Console.Error.WriteLine($"Error loading EPS: {loadEx.Message}");
                return;
            }

            using (image)
            {
                // Save as PNG with Grayscale palette
                Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Grayscale
                };
                image.Save(outputPngPath, pngOptions);

                // Save as SVG
                Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));
                var svgOptions = new SvgOptions();
                image.Save(outputSvgPath, svgOptions);
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
 * 1. When you need to safely import an EPS illustration and generate a grayscale PNG for web thumbnails while handling missing files or load failures.
 * 2. When your application must convert vector EPS artwork to scalable SVG files for responsive UI rendering and you want robust error reporting.
 * 3. When processing batch EPS documents on a server, you require automatic folder creation and exception handling to prevent crashes during image conversion.
 * 4. When integrating Aspose.Imaging into a C# service that reads user‑uploaded EPS files and must gracefully handle corrupted or unsupported EPS content.
 * 5. When building a desktop tool that transforms EPS logos into both PNG and SVG formats and needs clear console messages for any loading or saving errors.
 */
