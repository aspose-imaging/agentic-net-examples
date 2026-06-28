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

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CMX image
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Calculate new dimensions (uniform scale factor of 2)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize the image; this scales drawing and line thickness proportionally
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
 * 1. When a CAD engineer needs to double the size of a legacy CMX vector drawing for printing on a larger format plotter while preserving line weight, they can use this code.
 * 2. When a publishing workflow requires converting a CMX illustration to a higher‑resolution version for inclusion in a magazine layout, the uniform scaling ensures the artwork remains crisp and line thickness stays proportional.
 * 3. When a software that generates technical schematics must upscale a CMX file to match a new screen DPI setting, the C# Resize method keeps the diagram’s proportions accurate.
 * 4. When an archival system needs to create a scaled backup of CMX drawings for future reference without manually adjusting line styles, the Aspose.Imaging Resize operation automates the process.
 * 5. When a developer integrates CMX support into a .NET application that offers “zoom‑to‑fit” functionality, scaling the image by a factor of two provides a quick way to preview larger versions while maintaining visual fidelity.
 */