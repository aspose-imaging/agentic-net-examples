using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.pdf";

        // Verify that the input BMP file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF export options
            var pdfOptions = new PdfOptions
            {
                // Set the PDF page size to match the image dimensions for 1:1 fidelity
                PageSize = new Size(image.Width, image.Height)
            };

            // Save the image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}