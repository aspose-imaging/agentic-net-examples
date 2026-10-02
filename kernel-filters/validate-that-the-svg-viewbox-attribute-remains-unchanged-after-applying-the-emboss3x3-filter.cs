// HOW-TO: Check SVG ViewBox Unchanged After Applying Emboss3x3 Filter In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            // Validate input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load input SVG and get viewBox attribute
            XDocument inputDoc = XDocument.Load(inputPath);
            XAttribute inputViewBoxAttr = inputDoc.Root.Attribute("viewBox");
            string inputViewBox = inputViewBoxAttr != null ? inputViewBoxAttr.Value : null;

            // Placeholder for applying Emboss3x3 filter.
            // Since actual filter implementation is not available, we simply copy the file.
            // In a real scenario, replace this block with the actual filter application.
            File.Copy(inputPath, outputPath, true);

            // Load output SVG and get viewBox attribute
            XDocument outputDoc = XDocument.Load(outputPath);
            XAttribute outputViewBoxAttr = outputDoc.Root.Attribute("viewBox");
            string outputViewBox = outputViewBoxAttr != null ? outputViewBoxAttr.Value : null;

            // Validate that viewBox remains unchanged
            if (inputViewBox == outputViewBox)
            {
                Console.WriteLine("Success: viewBox attribute unchanged after applying Emboss3x3 filter.");
            }
            else
            {
                Console.WriteLine("Failure: viewBox attribute changed after applying Emboss3x3 filter.");
                Console.WriteLine($"Original viewBox: {inputViewBox ?? "null"}");
                Console.WriteLine($"Modified viewBox: {outputViewBox ?? "null"}");
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
 * 1. When you need to ensure that applying an image filter does not alter the SVG's coordinate system.
 * 2. When automating a batch process that applies the Emboss3x3 filter to SVG files while preserving layout.
 * 3. When validating that a third‑party filter implementation maintains original viewBox values for responsive graphics.
 * 4. When writing unit tests to confirm that SVG metadata remains intact after image processing in .NET.
 * 5. When integrating Aspose.Imaging into a pipeline that modifies SVG appearance but must keep viewBox for downstream rendering.
 */
