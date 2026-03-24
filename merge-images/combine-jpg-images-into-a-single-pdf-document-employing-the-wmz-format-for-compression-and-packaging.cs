using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
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

        // Create a multipage image from the JPG files
        // The overload with 'throwExceptionOnLoadError' set to false prevents exceptions on load errors
        using (Image multipageImage = Image.Create(inputPaths, false))
        {
            // Prepare PDF options with WMZ‑style compression (using Flate compression for PDF)
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    Compression = PdfImageCompressionOptions.Flate
                }
            };

            // Save the multipage image as a single PDF document
            multipageImage.Save(outputPath, pdfOptions);
        }
    }
}