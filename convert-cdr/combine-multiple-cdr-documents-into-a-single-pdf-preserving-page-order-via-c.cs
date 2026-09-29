// HOW-TO: Combine Multiple CDR Documents Into One PDF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "input1.cdr";
            string inputPath2 = "input2.cdr";
            string inputPath3 = "input3.cdr";

            if (!File.Exists(inputPath1)) { Console.Error.WriteLine($"File not found: {inputPath1}"); return; }
            if (!File.Exists(inputPath2)) { Console.Error.WriteLine($"File not found: {inputPath2}"); return; }
            if (!File.Exists(inputPath3)) { Console.Error.WriteLine($"File not found: {inputPath3}"); return; }

            using (Image img1 = Image.Load(inputPath1))
            using (Image img2 = Image.Load(inputPath2))
            using (Image img3 = Image.Load(inputPath3))
            {
                Image[] images = new Image[] { img1, img2, img3 };
                PdfOptions pdfOptions = new PdfOptions();

                string outputPath = "output/combined.pdf";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image pdf = Image.Create(images, true))
                {
                    pdf.Save(outputPath, pdfOptions);
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
 * 1. When a design team needs to merge several CorelDRAW (.cdr) drawings into a single PDF portfolio while preserving the original page sequence.
 * 2. When an automated build process must convert multiple CDR assets into a consolidated PDF report for client delivery.
 * 3. When a web service receives separate CDR files and must generate one downloadable PDF document for end‑users.
 * 4. When a desktop application needs to batch‑process CDR illustrations and produce a combined PDF for printing or archiving.
 * 5. When a document management system requires programmatic merging of CDR files into a PDF to maintain consistent ordering before indexing.
 */
