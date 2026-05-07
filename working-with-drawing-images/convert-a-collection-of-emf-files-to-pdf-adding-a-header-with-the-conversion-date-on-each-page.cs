using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\EmfFiles";
            string outputFolder = @"C:\PdfOutput";

            // Validate input directory
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add EMF files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all EMF files in the input folder
            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Validate each input file
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to EmfImage
                    EmfImage emfImage = (EmfImage)image;

                    // Obtain a graphics recorder for the EMF image
                    EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

                    // Draw header text with conversion date
                    string headerText = $"Converted on {DateTime.Now:yyyy-MM-dd}";
                    graphics.DrawString(headerText, new Font("Arial", 12), Color.Black, 10, 10);

                    // End recording to get a new EMF image with the header
                    using (EmfImage annotatedEmf = graphics.EndRecording())
                    {
                        // Save the annotated EMF as PDF
                        PdfOptions pdfOptions = new PdfOptions();
                        annotatedEmf.Save(outputPath, pdfOptions);
                    }
                }

                Console.WriteLine($"Converted '{inputPath}' to PDF at '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}