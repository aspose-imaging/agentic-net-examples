using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded list of SVG files to process
        string[] inputFiles = new[]
        {
            @"C:\SvgBatch\Input\illustration1.svg",
            @"C:\SvgBatch\Input\illustration2.svg",
            @"C:\SvgBatch\Input\illustration3.svg"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output PDF path (same folder, same name with .pdf extension)
            string outputPath = Path.ChangeExtension(inputPath, ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options
                var pdfOptions = new PdfOptions();

                // Attempt to read a description from a side‑car .txt file (same name as SVG)
                string descriptionPath = Path.ChangeExtension(inputPath, ".txt");
                string description = string.Empty;
                if (File.Exists(descriptionPath))
                {
                    description = File.ReadAllText(descriptionPath).Trim();
                }

                // Embed description into PDF metadata (using Title field)
                pdfOptions.PdfDocumentInfo = new Aspose.Imaging.FileFormats.Pdf.PdfDocumentInfo
                {
                    Title = description
                };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}