using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.emf";
        string outputPath = @"C:\output\fonts_report.txt";

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

                // Write fonts information to the report file
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine($"Report for EMF file: {Path.GetFileName(inputPath)}");
                    writer.WriteLine();

                    writer.WriteLine("Used fonts:");
                    foreach (string font in usedFonts)
                    {
                        writer.WriteLine($"Used font: {font}");
                    }

                    writer.WriteLine();
                    writer.WriteLine("Missed fonts (fonts not found on the system):");
                    foreach (string font in missedFonts)
                    {
                        writer.WriteLine($"Missed font: {font}");
                    }
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
 * 1. When a developer must verify that all fonts referenced in an EMF vector graphic are installed on a server before batch‑converting the files to PDF, they can extract the used and missed fonts and generate a text report.
 * 2. When a software solution needs to audit compliance with corporate branding guidelines by listing every font embedded in EMF files stored in a document repository, this code provides a quick searchable report.
 * 3. When a migration tool moves legacy Windows Metafile assets to a cloud‑based imaging platform, extracting the fonts helps identify missing typefaces that could cause rendering issues.
 * 4. When an automated build pipeline validates that design assets contain only approved fonts, the code can parse EMF files and output a report for quality‑assurance checks.
 * 5. When a developer builds a font‑usage analytics dashboard for a graphics editing application, extracting fonts from EMF files and logging them to a text file supplies the raw data needed for statistical analysis.
 */