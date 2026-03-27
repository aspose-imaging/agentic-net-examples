using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\input.emf";
        string outputPath = @"C:\Temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Read EMF file into a byte array
        byte[] emfBytes = File.ReadAllBytes(inputPath);

        // Load EMF image from byte array
        using (MemoryStream ms = new MemoryStream(emfBytes))
        using (Image image = Image.Load(ms))
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save directly to PDF
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}