// HOW-TO: Convert EPS to SVG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Aspose.Imaging does not provide a direct API to replace gradients with solid colors.
                // Implementing such a transformation would require custom rendering logic.
                // For the purpose of this example we proceed to save the image as SVG.

                var svgOptions = new SvgOptions();

                // Optional: configure rasterization options if needed
                // svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size };

                // Save the image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to programmatically transform legacy EPS artwork into scalable SVG files for web display using C#.
 * 2. When an automated build pipeline must convert batch EPS logos to SVG format to ensure resolution‑independent graphics in a .NET application.
 * 3. When a desktop tool has to import user‑provided EPS files and export them as SVG so they can be edited in vector editors without manual conversion.
 * 4. When a server‑side service generates reports that include EPS diagrams and must deliver them as SVG to browsers for faster rendering.
 * 5. When migrating a design asset library from EPS to SVG, you require a C# script that loads each EPS, optionally processes it, and saves it as SVG using Aspose.Imaging.
 */
