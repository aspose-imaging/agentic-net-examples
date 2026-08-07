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
            string inputFolder = @"C:\EmfInput";
            string outputFolder = @"C:\PdfOutput";

            // Ensure input directory exists
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add EMF files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Get all EMF files in the input folder
            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output PDF path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to EmfImage
                    EmfImage emfImage = (EmfImage)image;

                    // Create graphics recorder from EMF
                    EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

                    // Prepare header text (conversion date)
                    string headerText = DateTime.Now.ToString("yyyy-MM-dd");

                    // Draw header at top-left corner
                    graphics.DrawString(
                        headerText,
                        new Font("Arial", 12),
                        Color.Black,
                        10, // X position
                        10  // Y position
                    );

                    // End recording to obtain a new EMF with the header
                    using (EmfImage annotatedEmf = graphics.EndRecording())
                    {
                        // Save as PDF
                        annotatedEmf.Save(outputPath, new PdfOptions());
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
 * 1. When a company needs to archive a batch of vector‑based EMF diagrams as searchable PDF reports and wants each page stamped with the conversion date for compliance tracking.
 * 2. When an engineering team automates the generation of project documentation by converting daily‑exported EMF schematics into PDF files that include a header showing the date the files were processed.
 * 3. When a legal department must submit electronic evidence, converting EMF signatures into PDFs while adding a conversion‑date header to prove the timestamp of the conversion.
 * 4. When a medical imaging system exports patient charts as EMF files and requires a C# routine to bundle them into PDFs with a header indicating the date of conversion for record‑keeping.
 * 5. When a publishing workflow needs to transform a collection of EMF illustrations into PDF pages and automatically prepend a header with the current date to each page for version control.
 */