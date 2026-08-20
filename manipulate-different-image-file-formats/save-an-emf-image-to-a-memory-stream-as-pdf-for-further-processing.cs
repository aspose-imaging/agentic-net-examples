// HOW-TO: Convert EMF to PDF in Memory Stream Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\temp\sample.emf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Set up vector rasterization options for EMF
                var emfRasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure PDF save options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = emfRasterOptions
                };

                // Save to a memory stream as PDF
                using (MemoryStream pdfStream = new MemoryStream())
                {
                    image.Save(pdfStream, pdfOptions);

                    // Example of further processing: output the size of the PDF data
                    Console.WriteLine($"PDF size in bytes: {pdfStream.Length}");
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
 * 1. When you need to embed a vector EMF graphic into a PDF document without writing intermediate files.
 * 2. When you want to generate a PDF from an EMF image for sending over a web API that expects a byte array.
 * 3. When you must rasterize an EMF at its original size before converting it to PDF for printing workflows.
 * 4. When you need to measure or log the size of a PDF generated from an EMF before storing it in a database.
 * 5. When you are building a server‑side service that converts uploaded EMF files to PDF streams for further processing.
 */
