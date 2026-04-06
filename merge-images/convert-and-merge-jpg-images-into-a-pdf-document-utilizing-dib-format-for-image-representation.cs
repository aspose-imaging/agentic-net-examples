using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputFiles = new string[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hard‑coded output PDF file
        string outputFile = @"C:\Images\MergedOutput.pdf";

        // Verify that every input file exists
        foreach (string inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

        // Create a multipage image from the JPG files
        using (Image multipageImage = Image.Create(inputFiles))
        {
            // Prepare PDF export options
            PdfOptions pdfOptions = new PdfOptions
            {
                // Example: use automatic image compression inside the PDF
                // (optional, can be omitted if defaults are sufficient)
                // PdfImageCompressionOptions = PdfImageCompressionOptions.Auto // not a property, kept as comment for reference
            };

            // Save the multipage image as a PDF document
            multipageImage.Save(outputFile, pdfOptions);
        }
    }
}