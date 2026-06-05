using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            string inputPath = Path.Combine(inputDir, "sample.pdf");
            string outputPath = Path.Combine(outputDir, "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer must batch‑convert a library of SVG illustrations into PDF/A‑2b files for regulatory‑compliant archiving while embedding an ICC profile to ensure consistent color reproduction.
 * 2. When a publishing system needs to transform vector‑based SVG assets into print‑ready PDF/A‑2b documents with embedded color management for reliable output across different printers.
 * 3. When an e‑learning platform requires converting SVG diagrams into PDF/A‑2b coursework PDFs that retain exact brand colors by embedding the appropriate ICC profile.
 * 4. When a digital asset management tool automates the migration of SVG logos into PDF/A‑2b format for long‑term storage, preserving color fidelity through an embedded ICC profile.
 * 5. When a legal documentation workflow demands converting SVG signatures into PDF/A‑2b files that meet archival standards and include an ICC profile to guarantee color accuracy over time.
 */