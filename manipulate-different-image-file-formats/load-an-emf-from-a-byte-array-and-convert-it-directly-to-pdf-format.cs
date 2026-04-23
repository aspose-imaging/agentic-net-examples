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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\input.emf";
            string outputPath = @"C:\Temp\output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image from a byte array
            byte[] emfBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(emfBytes))
            using (Image image = Image.Load(ms))
            {
                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Convert and save the image directly to PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}