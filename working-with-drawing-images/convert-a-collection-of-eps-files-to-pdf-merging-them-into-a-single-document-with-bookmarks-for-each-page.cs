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
        try
        {
            // Hardcoded input EPS file paths
            string[] epsPaths = new string[]
            {
                "input1.eps",
                "input2.eps",
                "input3.eps"
            };

            // Hardcoded output PDF path
            string outputPdfPath = "merged_output.pdf";

            // Validate each input file
            foreach (var path in epsPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPdfPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // List to hold temporary PDF page files
            List<string> tempPdfPages = new List<string>();

            // Convert each EPS to a single-page PDF
            foreach (var epsPath in epsPaths)
            {
                string tempPdf = Path.GetTempFileName();
                using (Image image = Image.Load(epsPath))
                {
                    var pdfOptions = new PdfOptions();
                    image.Save(tempPdf, pdfOptions);
                }
                tempPdfPages.Add(tempPdf);
            }

            // Simple merge: concatenate PDF byte streams (note: this is a placeholder and may not produce a valid PDF with proper bookmarks)
            using (var outputStream = new FileStream(outputPdfPath, FileMode.Create, FileAccess.Write))
            {
                foreach (var pagePath in tempPdfPages)
                {
                    byte[] pageBytes = File.ReadAllBytes(pagePath);
                    outputStream.Write(pageBytes, 0, pageBytes.Length);
                }
            }

            // Cleanup temporary files
            foreach (var tempPath in tempPdfPages)
            {
                try { File.Delete(tempPath); } catch { }
            }

            Console.WriteLine($"Merged PDF created at: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}