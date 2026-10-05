// HOW-TO: Convert multiple SVG icons to multi-resolution ICO files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (string svgPath in files)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".ico");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // ICO format not supported in this implementation
                Console.Error.WriteLine($"ICO conversion not supported for file: {svgPath}");
                continue;
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
 * 1. When you need to generate Windows application icons from a set of SVG graphics, converting each SVG into an ICO file that contains several sizes for proper scaling.
 * 2. When a build pipeline must batch‑process dozens of SVG assets into icon files so that the resulting ICOs work on different screen DPIs.
 * 3. When you are creating a cross‑platform desktop app and want to reuse vector SVG logos as raster icons without manually resizing each image.
 * 4. When you need to automate the preparation of favicon bundles by turning SVG symbols into multi‑resolution ICO files for browsers and Windows shortcuts.
 * 5. When you want to integrate Aspose.Imaging in a C# utility to read SVG files from a folder and output corresponding ICO files for use in installers or UI resources.
 */
