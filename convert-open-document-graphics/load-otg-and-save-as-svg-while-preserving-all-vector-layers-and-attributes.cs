// HOW-TO: Convert OTG Vector Graphic to SVG with Layers in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.otg";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
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
 * 1. When a developer needs to import an OTG file from a design tool and export it as an SVG for web display while keeping all vector layers intact.
 * 2. When building a C# batch‑processing utility that converts multiple OTG drawings to scalable SVG files for inclusion in documentation or reports.
 * 3. When integrating Aspose.Imaging into a server‑side API that receives OTG uploads and returns SVG responses preserving original graphic attributes.
 * 4. When creating a desktop application that allows users to edit or preview OTG files and then save them as SVG without losing any vector information.
 * 5. When automating a migration workflow that transforms legacy OTG assets into modern SVG assets for use in responsive UI designs.
 */
