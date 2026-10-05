// HOW-TO: Extract First Frame from Animated APNG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.apng";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a static preview thumbnail from an animated APNG for a web gallery.
 * 2. When a mobile app only supports single‑frame PNGs and you must convert uploaded APNGs to a compatible format.
 * 3. When creating a PDF report that requires a non‑animated image, extracting the first frame of an APNG ensures it can be embedded.
 * 4. When optimizing storage by discarding animation and keeping only the initial frame of an APNG in a content management system.
 * 5. When processing user‑submitted APNG avatars and you need to save the first frame as a regular PNG for profile display.
 */
