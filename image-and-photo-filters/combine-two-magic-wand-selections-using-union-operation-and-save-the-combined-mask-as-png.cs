// HOW-TO: Combine Multiple Magic Wand Selections and Export Mask as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "combined_mask.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Union(new MagicWandSettings(100, 100))
                    .Apply();

                var options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to programmatically merge two region selections from a photo and create a single mask file for further editing or analysis.
 * 2. When building an automated workflow that extracts combined foreground areas from JPEG images for use in compositing or machine‑learning datasets.
 * 3. When generating precise cut‑out masks by uniting separate Magic Wand selections to isolate complex objects before exporting them as PNG.
 * 4. When creating batch scripts that process scanned documents, combining multiple selection areas into one mask to simplify OCR preprocessing.
 * 5. When developing a C# application that lets users click two points on an image, automatically unions the resulting selections and saves the result as a transparent PNG mask.
 */
