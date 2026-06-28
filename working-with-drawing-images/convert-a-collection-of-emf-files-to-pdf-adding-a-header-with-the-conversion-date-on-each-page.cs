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
            string inputFolder = @"C:\InputEmf";
            string outputFolder = @"C:\OutputPdf";

            // Validate input directory
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Get all EMF files
            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Validate each input file
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Create graphics recorder from the EMF image
                    EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

                    // Prepare header text with conversion date
                    string header = $"Converted on {DateTime.Now:yyyy-MM-dd}";
                    Font headerFont = new Font("Arial", 12);
                    Color headerColor = Color.Black;

                    // Draw header at top-left corner
                    graphics.DrawString(header, headerFont, headerColor, 10, 10);

                    // End recording to obtain modified EMF image
                    using (EmfImage modifiedEmf = graphics.EndRecording())
                    {
                        // Prepare output PDF path
                        string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save as PDF
                        PdfOptions pdfOptions = new PdfOptions();
                        modifiedEmf.Save(outputPath, pdfOptions);
                    }
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
 * 1. When a company needs to archive a batch of vector‑based engineering drawings stored as EMF files into searchable PDF reports that include the conversion date on each page.
 * 2. When an automated build pipeline must generate PDF documentation from EMF icons and add a timestamp header for compliance auditing.
 * 3. When a legal firm converts client‑submitted EMF signatures into PDF files and wants the conversion date displayed as a header for evidentiary purposes.
 * 4. When a desktop application processes user‑uploaded EMF charts and produces PDF summaries with a date header to track when the data was transformed.
 * 5. When a cloud service batch‑processes thousands of EMF marketing assets into PDF brochures, inserting a header with the current date to ensure version control across distributed teams.
 */