// HOW-TO: Convert EPS File to SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace EpsToSvgConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "output.svg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (Image image = Image.Load(inputPath))
                {
                    SvgOptions options = new SvgOptions();
                    image.Save(outputPath, options);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to display high‑resolution vector artwork from a legacy EPS file on the web, they can convert it to scalable SVG with this code.
 * 2. When an automated build pipeline must transform design assets into a web‑friendly format, the snippet enables batch conversion of EPS to SVG in C#.
 * 3. When a desktop application imports EPS logos and must export them as editable SVG for further editing, this example shows how to perform the conversion using Aspose.Imaging.
 * 4. When a reporting service generates charts in EPS and the client requires them as SVG for responsive dashboards, the code provides a simple way to re‑encode the images.
 * 5. When a migration project moves print‑ready EPS files to a modern vector format without losing quality, developers can use this routine to programmatically save them as SVG.
 */
