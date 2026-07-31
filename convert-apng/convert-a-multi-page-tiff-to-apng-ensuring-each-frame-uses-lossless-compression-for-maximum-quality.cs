using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.apng";

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

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // Save as APNG with default (lossless) PNG compression
                image.Save(outputPath, new ApngOptions());
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
 * 1. When a developer needs to transform a multi‑page TIFF scan of a document into a single animated PNG for web display while preserving every pixel with lossless compression, they can use this code.
 * 2. When an application must generate high‑quality animated previews of medical imaging series stored as TIFF stacks for integration into a browser‑based viewer, the snippet provides a straightforward C# solution.
 * 3. When a digital archivist wants to convert scanned archival photographs saved as multi‑page TIFFs into lightweight APNG animations for online galleries without sacrificing image fidelity, this code handles the conversion.
 * 4. When a reporting tool creates multi‑page TIFF charts and needs to embed them as animated PNGs in PDF or HTML reports to reduce file size while keeping lossless quality, the example demonstrates the required steps.
 * 5. When a game developer imports sprite sheets delivered as multi‑page TIFF files and needs to export them as losslessly compressed APNG animations for use in Unity or other engines, this code performs the conversion.
 */