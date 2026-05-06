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
        string outputPath = @"C:\Images\font_report.txt";

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

                // Write the report to the output file
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("=== Used Fonts ===");
                    foreach (string font in usedFonts)
                    {
                        writer.WriteLine(font);
                    }

                    writer.WriteLine();
                    writer.WriteLine("=== Missed Fonts ===");
                    foreach (string font in missedFonts)
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