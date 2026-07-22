using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\fonts_report.txt";

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

            // Load the EMF file as a MetaImage
            using (MetaImage image = (MetaImage)Image.Load(inputPath))
            {
                // Retrieve used and missed fonts
                string[] usedFonts = image.GetUsedFonts();
                string[] missedFonts = image.GetMissedFonts();

                // Write report
                using (StreamWriter writer = new StreamWriter(outputPath, false))
                {
                    writer.WriteLine("=== Used Fonts ===");
                    foreach (string font in usedFonts)
                    {
                        writer.WriteLine(font);
                    }

                    writer.WriteLine();
                    writer.WriteLine("=== Missed Fonts (not found) ===");
                    foreach (string font in missedFonts)
                    {
                        writer.WriteLine(font);
                    }
                }
            }

            Console.WriteLine($"Font report generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to audit which fonts are embedded in a Windows Metafile (EMF) before converting it to PDF to ensure proper font rendering.
 * 2. When a software system must generate a compliance report listing all fonts used and missing in EMF graphics for corporate branding guidelines.
 * 3. When an automated build pipeline validates that all required fonts are present in EMF assets to prevent missing‑font errors in downstream image processing.
 * 4. When a legacy application migrates EMF drawings to a new platform and requires a text inventory of used and unavailable fonts for licensing verification.
 * 5. When a document management solution extracts font information from uploaded EMF files to populate metadata fields for search and indexing.
 */