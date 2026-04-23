using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.emf";
        string outputPath = @"C:\Temp\output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Save to a memory stream as PDF
                using (MemoryStream pdfStream = new MemoryStream())
                {
                    emfImage.Save(pdfStream, pdfOptions);

                    // Example of further processing: write the PDF bytes to a file
                    File.WriteAllBytes(outputPath, pdfStream.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}