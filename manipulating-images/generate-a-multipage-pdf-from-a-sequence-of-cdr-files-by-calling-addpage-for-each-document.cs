using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CDR files
            string[] inputPaths = new string[]
            {
                @"C:\Input\file1.cdr",
                @"C:\Input\file2.cdr",
                @"C:\Input\file3.cdr"
            };

            // Hardcoded output PDF file
            string outputPath = @"C:\Output\combined.pdf";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare PDF export options with MultiPageOptions that reference all input files
            PdfOptions pdfOptions = new PdfOptions
            {
                // MultiPageOptions can accept an array of file names to be merged into a single PDF
                MultiPageOptions = new MultiPageOptions(inputPaths)
            };

            // Load the first CDR file (any image can be used to invoke Save with the MultiPageOptions)
            using (Image image = Image.Load(inputPaths[0]))
            {
                // Save the combined PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to merge multiple CorelDRAW (CDR) design files into a single searchable PDF for easy distribution to clients.
 * 2. When an automation script must convert a batch of CDR assets into a consolidated PDF report for inclusion in a product catalog.
 * 3. When a document management system requires on‑the‑fly generation of a multi‑page PDF from several CDR drawings to store as a single archive file.
 * 4. When a Windows service processes incoming CDR files and needs to combine them into one PDF for printing or electronic signing.
 * 5. When a C# application integrates Aspose.Imaging to transform a series of CDR illustrations into a unified PDF portfolio for marketing presentations.
 */