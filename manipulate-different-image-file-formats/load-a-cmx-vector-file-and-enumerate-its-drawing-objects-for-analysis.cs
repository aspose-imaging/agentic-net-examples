using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cmx";
            string outputPath = "report.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    int pageIndex = 0;
                    foreach (var page in cmx.Pages)
                    {
                        writer.WriteLine($"Page {pageIndex}:");
                        writer.WriteLine($"  Width: {page.Width}");
                        writer.WriteLine($"  Height: {page.Height}");
                        writer.WriteLine($"  Bounds: {page.Bounds}");
                        pageIndex++;
                    }
                }

                Console.WriteLine($"Enumeration completed. Report saved to {outputPath}");
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
 * 1. When a developer needs to extract page dimensions and bounds from a CMX vector file to generate a printable layout report for a CAD workflow.
 * 2. When an application must validate that all pages in a multi‑page CMX drawing meet specific size constraints before converting them to PDF.
 * 3. When a quality‑control tool has to enumerate each page of a CMX file to log its width, height, and bounding box for downstream analytics.
 * 4. When a migration script needs to read CMX files and produce a plain‑text inventory of page metadata to assist in bulk asset management.
 * 5. When a C# service uses Aspose.Imaging to load CMX drawings and create a summary file that can be indexed by search engines for quick document discovery.
 */