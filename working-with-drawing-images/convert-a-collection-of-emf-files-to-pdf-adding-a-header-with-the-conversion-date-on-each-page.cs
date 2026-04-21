using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\InputEmf";
        string outputFolder = @"C:\OutputPdf";

        // Validate input directory
        if (!Directory.Exists(inputFolder))
        {
            Directory.CreateDirectory(inputFolder);
            Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
            return;
        }

        // Get all EMF files
        string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

        foreach (string inputPath in emfFiles)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EMF image
            using (Image image = Image.Load(inputPath))
            {
                EmfImage emfImage = (EmfImage)image;

                // Create graphics recorder from the EMF image
                EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

                // Draw header with conversion date
                graphics.DrawString(
                    $"Converted on {DateTime.Now:yyyy-MM-dd}",
                    new Font("Arial", 24),
                    Color.Black,
                    10,
                    10);

                // End recording to obtain a new EMF image containing the header
                using (EmfImage newEmf = graphics.EndRecording())
                {
                    // Save as PDF
                    PdfOptions pdfOptions = new PdfOptions();
                    newEmf.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}