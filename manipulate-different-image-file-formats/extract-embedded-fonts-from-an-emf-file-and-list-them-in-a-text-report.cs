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

                // Write the report
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("=== Used Fonts ===");
                    foreach (string font in usedFonts)
                    {
                        writer.WriteLine(font);
                    }

                    writer.WriteLine();
                    writer.WriteLine("=== Missed (Embedded) Fonts ===");
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
 * 1. When a C# application must audit which fonts are actually used versus embedded in a Windows Metafile (EMF) before converting it to PDF, the code can extract the font lists and generate a text report.
 * 2. When a document management system needs to verify licensing compliance by identifying missing (embedded) fonts in EMF graphics, developers can run this Aspose.Imaging routine to list used and missed fonts.
 * 3. When an automated build pipeline processes vector graphics and must log font dependencies for each EMF file to aid troubleshooting of rendering issues, the code provides a straightforward way to create a fonts_report.txt.
 * 4. When a migration tool moves legacy EMF assets to a new design platform and must document which fonts are embedded to recreate the visual fidelity, this C# snippet extracts and records the font information.
 * 5. When a quality‑assurance script checks that all required fonts are present in EMF files supplied by third‑party vendors, the example uses Aspose.Imaging’s GetUsedFonts and GetMissedFonts methods to generate a readable report.
 */