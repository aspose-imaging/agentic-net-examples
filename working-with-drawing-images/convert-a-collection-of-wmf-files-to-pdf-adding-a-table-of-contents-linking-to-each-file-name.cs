using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded collection of WMF input files
        string[] wmfFiles = new[]
        {
            @"C:\Images\file1.wmf",
            @"C:\Images\file2.wmf",
            @"C:\Images\file3.wmf"
        };

        // Output directory for PDFs
        string outputDir = @"C:\Output\Pdf";
        Directory.CreateDirectory(outputDir);

        // List to hold TOC entries
        List<string> tocLines = new List<string>();
        tocLines.Add("Table of Contents");
        tocLines.Add("=================");

        foreach (string wmfPath in wmfFiles)
        {
            // Validate input file existence
            if (!File.Exists(wmfPath))
            {
                Console.Error.WriteLine($"File not found: {wmfPath}");
                continue;
            }

            // Determine PDF output path
            string pdfFileName = Path.GetFileNameWithoutExtension(wmfPath) + ".pdf";
            string pdfPath = Path.Combine(outputDir, pdfFileName);

            // Ensure output directory exists (already created above, but rule requires unconditional call)
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Load WMF and save as PDF
            using (Image image = Image.Load(wmfPath))
            {
                image.Save(pdfPath, new PdfOptions());
            }

            // Add entry to TOC
            tocLines.Add($"{Path.GetFileName(wmfPath)} -> {pdfFileName}");
        }

        // Write TOC to a text file
        string tocPath = Path.Combine(outputDir, "TableOfContents.txt");
        Directory.CreateDirectory(Path.GetDirectoryName(tocPath));
        File.WriteAllLines(tocPath, tocLines);
    }
}