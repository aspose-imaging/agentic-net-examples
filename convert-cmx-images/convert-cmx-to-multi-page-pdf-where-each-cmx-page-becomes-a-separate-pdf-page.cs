using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX document
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Configure PDF export options
            PdfOptions pdfOptions = new PdfOptions
            {
                // Export all pages (null means no page range restriction)
                MultiPageOptions = null
            };

            // Save as a multi‑page PDF where each CMX page becomes a PDF page
            cmxImage.Save(outputPath, pdfOptions);
        }
    }
}