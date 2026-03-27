using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Temp\input.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Prepare a memory stream to hold the PDF data
            using (MemoryStream pdfStream = new MemoryStream())
            {
                // Create PDF save options (default settings)
                PdfOptions pdfOptions = new PdfOptions();

                // Save the EMF image to the memory stream as PDF
                emfImage.Save(pdfStream, pdfOptions);

                // Example processing: output the size of the generated PDF
                Console.WriteLine($"PDF generated in memory. Size: {pdfStream.Length} bytes");
            }
        }
    }
}