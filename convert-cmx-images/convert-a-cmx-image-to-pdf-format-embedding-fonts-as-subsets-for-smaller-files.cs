// HOW-TO: Convert CMX to PDF with Embedded Subset Fonts in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                cmx.Save(outputPath, pdfOptions);
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
 * 1. When you need to convert legacy CorelDRAW CMX artwork to a PDF for client review while keeping the file size low.
 * 2. When an automated document pipeline must transform CMX drawings into searchable PDFs that preserve original fonts as subsets.
 * 3. When a web service receives CMX files and must deliver PDF versions that embed only the used characters to reduce bandwidth.
 * 4. When integrating Aspose.Imaging into a C# application to batch‑process CMX graphics into PDF for archival with embedded font subsets.
 * 5. When generating printable PDFs from CMX designs in a Windows desktop tool, ensuring the fonts are subsetted to meet publishing standards.
 */
