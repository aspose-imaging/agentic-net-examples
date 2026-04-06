using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPEG files
        string[] inputPaths = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hard‑coded output PDF file
        string outputPath = @"C:\Images\Combined.pdf";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPEG files
        using (Image multiPageImage = Image.Create(inputPaths))
        {
            // Prepare PDF save options – keep original image resolution
            PdfOptions pdfOptions = new PdfOptions
            {
                UseOriginalImageResolution = true
            };

            // Save the multipage image as a PDF document
            multiPageImage.Save(outputPath, pdfOptions);
        }
    }
}