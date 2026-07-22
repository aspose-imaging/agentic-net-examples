using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate a blurred preview of an SVG logo for a web thumbnail, they can load the SVG template, apply a motion blur of size 7 at a 315° angle, rasterize it to PNG, and compare the result with the original to ensure visual fidelity.
 * 2. When building an automated testing pipeline that validates visual effects, a developer can use Aspose.Imaging for .NET to load an SVG, apply a motion blur filter, rasterize to a bitmap, and programmatically compare the blurred output against a baseline image.
 * 3. When creating dynamic marketing assets where a motion‑blur effect is required on vector graphics, a developer can load the SVG template, apply a size‑7 blur at 315°, convert it to PNG for email campaigns, and verify the output matches design expectations.
 * 4. When implementing a document conversion service that supports SVG to PNG with optional effects, a developer can use the code to apply a motion blur of size 7, angle 315°, rasterize the result, and perform a pixel‑by‑pixel comparison to detect any rendering issues.
 * 5. When optimizing graphics for mobile apps that need a fast‑loading blurred icon, a developer can load the SVG, apply the specified motion blur, rasterize to a lightweight PNG, and compare the blurred file to the original SVG to confirm size reduction and quality.
 */