using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string inputPath = Path.Combine(inputDirectory, "sample.png");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputDirectory, "sample.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PdfOptions());
            }

            Console.WriteLine($"Converted {inputPath} to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a publishing system must archive a collection of SVG graphics as PDF/A‑2b documents with embedded ICC profiles to guarantee color consistency and long‑term preservation.
 * 2. When an e‑commerce platform needs to batch‑convert designer‑provided SVG logos into PDF/A‑2b files that meet archival standards and retain accurate colors via ICC profiles.
 * 3. When a regulatory compliance tool requires transforming SVG schematics into PDF/A‑2b reports with embedded ICC color profiles to satisfy industry‑mandated color management rules.
 * 4. When a digital asset management (DAM) solution automates the ingestion of SVG artwork and stores each file as a PDF/A‑2b document with an ICC profile for consistent rendering in downstream workflows.
 * 5. When a medical imaging application embeds SVG anatomical diagrams into PDF/A‑2b case files, preserving exact colors through ICC profiles for reliable diagnostic review.
 */