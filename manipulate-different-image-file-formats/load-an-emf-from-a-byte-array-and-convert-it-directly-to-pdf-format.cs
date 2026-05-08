using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.emf";
        string outputPath = "Output\\sample.pdf";

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

            // Load EMF from byte array
            byte[] emfBytes = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(emfBytes))
            {
                using (EmfImage emfImage = (EmfImage)Image.Load(memoryStream))
                {
                    // Convert to PDF
                    PdfOptions pdfOptions = new PdfOptions();
                    emfImage.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}