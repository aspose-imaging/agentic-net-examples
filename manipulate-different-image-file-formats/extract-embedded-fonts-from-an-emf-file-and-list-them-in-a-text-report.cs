// HOW-TO: Extract Embedded Fonts from EMF and Generate Text Report in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "C:\\path\\to\\input.emf";
        string outputPath = "C:\\path\\to\\fonts_report.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (MetaImage image = (MetaImage)Image.Load(inputPath))
            {
                string[] usedFonts = image.GetUsedFonts();
                string[] missedFonts = image.GetMissedFonts();

                using (var writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("Used Fonts:");
                    foreach (var font in usedFonts)
                    {
                        writer.WriteLine(font);
                    }

                    writer.WriteLine();
                    writer.WriteLine("Missed Fonts:");
                    foreach (var font in missedFonts)
                    {
                        writer.WriteLine(font);
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
 * 1. When you need to audit which fonts are actually embedded in an EMF vector graphic to ensure proper rendering on systems without those fonts.
 * 2. When preparing a compliance report that lists used and missing fonts in EMF files before publishing documents.
 * 3. When troubleshooting printing issues caused by unavailable fonts in EMF images by identifying which fonts are missing.
 * 4. When migrating legacy EMF assets to a new design workflow and you must verify that all required fonts are present.
 * 5. When building an automated tool that scans a batch of EMF files and creates a summary of font usage for asset management.
 */
