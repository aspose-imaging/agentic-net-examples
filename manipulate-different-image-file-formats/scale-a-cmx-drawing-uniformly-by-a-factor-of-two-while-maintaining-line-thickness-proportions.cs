using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample_scaled.cmx";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Scale uniformly by a factor of 2
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight);

                // Save the scaled image
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
 * 1. When a CAD system needs to double the size of a CMX drawing for printing on larger paper while keeping line thickness proportional, a developer can use this code to resize the image uniformly.
 * 2. When an engineering workflow requires generating high‑resolution previews of legacy CorelDRAW CMX files for a web portal, the code scales the drawing by a factor of two without distorting line weights.
 * 3. When a batch‑processing tool must prepare CMX drawings for laser‑cutting machines that operate at a larger scale, developers can apply this C# snippet to enlarge the artwork while preserving stroke thickness.
 * 4. When a documentation generator needs to embed enlarged CMX schematics into PDF reports, the code provides a simple way to double the dimensions and maintain visual fidelity.
 * 5. When a legacy design archive is being migrated to a modern system that expects larger rasterized assets, this example shows how to programmatically resize CMX files in .NET while keeping line thickness consistent.
 */