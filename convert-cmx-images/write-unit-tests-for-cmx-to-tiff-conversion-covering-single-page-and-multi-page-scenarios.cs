// HOW-TO: Convert Single and Multi Page CMX Files to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Single-page CMX to TIFF
            string singleInput = Path.Combine(inputDir, "single_page.cmx");
            string singleOutput = Path.Combine(outputDir, "single_page.tif");

            if (!File.Exists(singleInput))
            {
                Console.Error.WriteLine($"File not found: {singleInput}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(singleOutput));

            using (Image image = Image.Load(singleInput))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(singleOutput, tiffOptions);
            }

            if (File.Exists(singleOutput))
                Console.WriteLine("Single-page CMX to TIFF conversion succeeded.");
            else
                Console.Error.WriteLine("Single-page conversion failed.");

            // Multi-page CMX to TIFF
            string multiInput = Path.Combine(inputDir, "multi_page.cmx");
            string multiOutput = Path.Combine(outputDir, "multi_page.tif");

            if (!File.Exists(multiInput))
            {
                Console.Error.WriteLine($"File not found: {multiInput}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(multiOutput));

            using (Image image = Image.Load(multiInput))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(multiOutput, tiffOptions);
            }

            if (File.Exists(multiOutput))
                Console.WriteLine("Multi-page CMX to TIFF conversion succeeded.");
            else
                Console.Error.WriteLine("Multi-page conversion failed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to programmatically convert legacy CMX drawings to TIFF for archival or printing, ensuring both single‑page and multi‑page documents are handled.
 * 2. When integrating a document management system that must accept CMX files and store them as TIFF images for compatibility with downstream workflows.
 * 3. When creating an automated batch process that converts incoming CMX design files to TIFF to generate preview thumbnails or PDFs.
 * 4. When building a migration tool that moves engineering drawings from CorelDRAW formats to TIFF for use in GIS or CAD applications.
 * 5. When writing unit tests to verify that Aspose.Imaging correctly preserves page count and image quality during CMX‑to‑TIFF conversion.
 */
