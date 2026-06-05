using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

public class Program
{
    static void Main(string[] args)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX drawing
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Scale uniformly by a factor of two
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight);

                // Save the scaled drawing
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
 * 1. When a CAD engineer needs to double the size of a legacy CMX drawing for printing on larger format paper while preserving line thickness, they can use this C# Aspose.Imaging code.
 * 2. When a manufacturing workflow requires converting a small CMX schematic into a higher‑resolution version for detailed inspection on a touchscreen display, the uniform scaling routine simplifies the process.
 * 3. When a GIS developer must upscale a CMX map to match a new coordinate grid without distorting line weights, the image.Resize call in C# provides a quick solution.
 * 4. When an archival system needs to store CMX drawings at twice their original dimensions to meet a client’s branding guidelines, the Aspose.Imaging CmxImage class handles the resize automatically.
 * 5. When a software vendor integrates CMX support into a .NET reporting tool and wants to enlarge diagrams for slide presentations while keeping stroke widths consistent, this code performs the required scaling.
 */