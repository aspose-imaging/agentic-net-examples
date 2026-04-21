using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\input.emf";
        string outputPath = "C:\\temp\\fonts_report.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EMF image as MetaImage
        using (MetaImage image = (MetaImage)Image.Load(inputPath))
        {
            // Retrieve used and missed fonts
            string[] usedFonts = image.GetUsedFonts();
            string[] missedFonts = image.GetMissedFonts();

            // Write report to text file
            using (StreamWriter writer = new StreamWriter(outputPath, false))
            {
                writer.WriteLine($"Font report for {Path.GetFileName(inputPath)}");
                writer.WriteLine("=== Used Fonts ===");
                foreach (string font in usedFonts)
                {
                    writer.WriteLine(font);
                }

                writer.WriteLine("=== Missed Fonts ===");
                foreach (string font in missedFonts)
                {
                    writer.WriteLine(font);
                }
            }
        }

        Console.WriteLine("Font report generated.");
    }
}