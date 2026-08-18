// HOW-TO: Convert EMF Byte Array To PDF Directly In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.emf";
        string outputPath = @"C:\Temp\Result\sample.pdf";

        // Ensure any runtime exception is caught and reported
        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create the output directory unconditionally
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EMF image from a byte array (memory stream)
            byte[] emfBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(emfBytes))
            using (Image image = Image.Load(ms))
            {
                // Save the image directly to PDF format
                image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to generate a PDF report from a vector EMF logo stored in memory without writing intermediate files.
 * 2. When a web service receives an EMF image as a byte stream and must return a PDF document to the client.
 * 3. When automating batch conversion of EMF drawings saved in a database to PDF for archival purposes.
 * 4. When integrating with a third‑party API that supplies EMF data and expects PDF output for printing.
 * 5. When creating a PDF invoice that embeds an EMF‑based chart that is only available as a byte array.
 */
