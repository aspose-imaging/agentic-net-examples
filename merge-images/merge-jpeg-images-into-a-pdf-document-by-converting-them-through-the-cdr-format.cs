using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hardcoded output PDF file
        string outputPath = @"C:\Images\MergedOutput.pdf";

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

        // Create a multipage image from the JPEG files
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Prepare PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Configure vector rasterization options (similar to CDR conversion)
            pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                // Use dimensions of the first page as the PDF page size
                PageWidth = multipageImage.Width,
                PageHeight = multipageImage.Height
            };

            // Save the multipage image as a PDF document
            multipageImage.Save(outputPath, pdfOptions);
        }
    }
}