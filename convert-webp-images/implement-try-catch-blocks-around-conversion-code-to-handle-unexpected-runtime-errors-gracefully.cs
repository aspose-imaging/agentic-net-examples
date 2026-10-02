// HOW-TO: Convert JPEG to PNG with Error Handling in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to batch‑convert user‑uploaded JPEG photos to PNG for web display while ensuring missing files are reported gracefully.
 * 2. When an automated image pipeline must create output folders on the fly before saving converted PNGs to avoid path errors.
 * 3. When you want to protect a desktop application from crashing by catching exceptions during image loading or saving with Aspose.Imaging.
 * 4. When a server‑side service processes incoming JPEGs and must log clear error messages if the conversion fails.
 * 5. When you are integrating Aspose.Imaging into a C# project and require a simple try‑catch pattern to handle unexpected runtime issues during format conversion.
 */
