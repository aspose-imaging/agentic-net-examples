using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Temp\sample.emf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Create a memory stream to hold the PDF output
                using (MemoryStream pdfStream = new MemoryStream())
                {
                    // Set up PDF save options (default settings)
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the EMF image into the memory stream as PDF
                    emfImage.Save(pdfStream, pdfOptions);

                    // The PDF data is now available in pdfStream
                    Console.WriteLine($"PDF saved to memory stream. Length = {pdfStream.Length} bytes.");
                    
                    // Example of further processing: reset position if needed
                    // pdfStream.Position = 0;
                    // ... process the PDF bytes ...
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}