// HOW-TO: Convert SVG to EMF and Flatten Layers Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "data/input.svg";
            string outputPath = "output/result.emf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // No explicit layer flattening needed for vector images in Aspose.Imaging.
                var options = new EmfOptions();
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
 * 1. When you need to embed an SVG diagram into a Microsoft Office document that only accepts EMF format.
 * 2. When you must provide a high‑resolution vector image for printing systems that require EMF files.
 * 3. When you want to simplify a multi‑layer SVG into a single‑layer vector for compatibility with legacy Windows applications.
 * 4. When you are building a batch conversion tool that transforms web‑friendly SVG assets into EMF for use in Windows Forms controls.
 * 5. When you need to programmatically generate EMF files from SVG icons to ensure lossless scaling in a C# desktop application.
 */
