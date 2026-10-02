// HOW-TO: Batch Convert CDR To PDF Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input file paths
            string[] inputPaths = new string[]
            {
                @"C:\Input\file1.cdr",
                @"C:\Input\file2.cdr",
                @"C:\Input\file3.cdr"
            };

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same folder, .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR and save as PDF with default settings
                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions options = new PdfOptions();
                    image.Save(outputPath, options);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to automate the conversion of several CorelDRAW (.cdr) drawings into PDF documents for archiving or sharing without manually opening each file.
 * 2. When a desktop application must generate PDFs from a list of CDR files supplied by the user, ensuring the output files are saved in the same folder.
 * 3. When a server‑side service processes uploaded CDR assets in bulk and creates PDF versions for preview in a web portal.
 * 4. When you want to integrate Aspose.Imaging into a build script that converts design files to PDF as part of a continuous‑integration pipeline.
 * 5. When an internal tool has to verify that each CDR file exists before converting it to PDF, creating the necessary output directories automatically.
 */
