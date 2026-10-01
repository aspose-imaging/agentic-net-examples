// HOW-TO: Convert ODG to PNG in C# with Proper Resource Disposal (Aspose.Imaging for .NET)
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
            string inputPath = "input.odg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

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
 * 1. When a desktop application needs to display OpenDocument graphics as PNG thumbnails, this code safely loads the ODG file and saves it as a PNG while ensuring memory is released.
 * 2. When a server‑side service receives ODG uploads and must convert them to web‑friendly PNGs, the using block guarantees that image resources are disposed after each conversion.
 * 3. When automating a batch job that processes a folder of ODG drawings into PNG assets for a mobile app, the pattern prevents file locks and leaks during high‑volume processing.
 * 4. When integrating Aspose.Imaging into a C# reporting tool that embeds ODG diagrams into PDF reports, converting them to PNG first ensures compatibility with the PDF renderer.
 * 5. When building a CI/CD pipeline that validates design assets by converting ODG files to PNG for visual diff checks, proper disposal avoids out‑of‑memory errors on build agents.
 */
