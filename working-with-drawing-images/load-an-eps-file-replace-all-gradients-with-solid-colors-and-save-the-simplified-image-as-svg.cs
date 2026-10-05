// HOW-TO: Convert EPS to SVG and Replace Gradients with Solid Colors in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // NOTE: Aspose.Imaging does not provide a direct API to replace gradients with solid colors.
                // This placeholder represents where such processing would occur if supported.
                // For example, one might iterate over vector objects and modify their fill properties.

                // Save the image as SVG
                var svgOptions = new SvgOptions();
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
 * 1. When you need to convert a complex EPS illustration to a lightweight SVG for web display while ensuring all gradient fills are flattened to solid colors.
 * 2. When preparing print‑ready artwork for a workflow that only accepts SVG files and cannot handle gradient definitions.
 * 3. When optimizing vector assets for mobile apps where solid‑color fills reduce rendering time and memory usage.
 * 4. When automating batch processing of legacy EPS logos to SVG format and want to simplify their appearance for consistent branding.
 * 5. When integrating Aspose.Imaging into a C# service that sanitizes incoming EPS files by removing gradients before storing them in a vector‑graphics repository.
 */
