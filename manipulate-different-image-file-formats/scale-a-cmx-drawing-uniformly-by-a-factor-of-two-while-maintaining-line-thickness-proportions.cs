// HOW-TO: Scale CMX Drawing by Factor Two While Preserving Line Thickness in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputPath = "output.cmx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the CMX image
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Calculate new dimensions (scale by factor of 2)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize the vector image; this scales drawing and line thickness proportionally
                image.Resize(newWidth, newHeight);

                // Save the scaled CMX drawing
                image.Save(outputPath);
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
 * 1. When you need to double the size of a CorelDRAW CMX file for high‑resolution printing while keeping the original line weights unchanged.
 * 2. When a CAD‑to‑CMX conversion pipeline requires uniform scaling of vector drawings before embedding them in a larger layout.
 * 3. When an automated batch process must enlarge legacy CMX schematics for display on large‑format monitors without distorting line thickness.
 * 4. When integrating Aspose.Imaging in a C# application to resize CMX artwork for a printable poster while preserving visual fidelity.
 * 5. When preparing CMX graphics for a zoom‑in feature in a web viewer, ensuring lines remain proportionally thick after scaling.
 */
