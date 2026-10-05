// HOW-TO: Convert ODG File to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

            using (Image image = Image.Load(inputPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
                PngOptions options = new PngOptions();
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
 * 1. When you need to display an OpenDocument Graphic (ODG) on a website, you can convert it to a PNG thumbnail with Aspose.Imaging in C#.
 * 2. When generating reports that embed vector drawings, converting ODG diagrams to PNG ensures compatibility with PDF or Word exporters.
 * 3. When building a desktop application that lets users import ODG assets and export them as raster images for printing, this code handles the conversion.
 * 4. When creating an automated batch job that processes a folder of ODG files and saves them as PNGs for archival or further image analysis.
 * 5. When developing a cloud API that receives ODG uploads and returns PNG previews, the snippet shows how to load and save the image in C#.
 */
