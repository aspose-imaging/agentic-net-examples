// HOW-TO: Convert Each Page Of A Multi‑Page CDR To Separate PSD Files In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input CDR file and output directory
        string inputPath = @"C:\temp\sample.cdr";
        string outputDir = @"C:\temp\output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Cache the whole document to avoid repeated I/O
                cdrImage.CacheData();

                // Iterate through each page
                foreach (CdrImagePage page in cdrImage.Pages)
                {
                    // Cache individual page data
                    page.CacheData();

                    // Build output file path for this page
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.psd");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Prepare PSD save options (default preserves original color depth)
                    PsdOptions psdOptions = new PsdOptions();

                    // Save the page as a PSD file
                    page.Save(outputPath, psdOptions);
                }
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
 * 1. When a designer needs to extract individual pages from a multi‑page CorelDRAW file for editing in Photoshop.
 * 2. When an automated batch process must convert archived CDR documents into PSD format while preserving the original color depth.
 * 3. When a web service receives CDR uploads and must provide each page as a separate PSD for downstream graphics pipelines.
 * 4. When a migration tool moves legacy CDR assets to a Photoshop‑based workflow without losing color fidelity.
 * 5. When a CI/CD pipeline validates that each page of a CDR file can be rendered correctly as a PSD for quality assurance.
 */
