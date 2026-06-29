using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access cropping
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid EMF image.");
                    return;
                }

                // Determine the cropping rectangle (remove a 10‑pixel border on each side)
                var bounds = emfImage.Bounds;
                int margin = 10;
                var cropRect = new Rectangle(
                    bounds.X + margin,
                    bounds.Y + margin,
                    Math.Max(0, bounds.Width - 2 * margin),
                    Math.Max(0, bounds.Height - 2 * margin));

                // Perform cropping
                emfImage.Crop(cropRect);

                // Save the cropped image as PDF
                var pdfOptions = new PdfOptions();
                emfImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to remove unwanted white space around a vector graphic stored in an EMF file before embedding it in a PDF report.
 * 2. When an application must automatically trim a fixed‑pixel border from scanned EMF diagrams and generate a PDF for distribution.
 * 3. When a batch‑processing tool has to convert legacy EMF logos into PDF while ensuring the logo edges are tightly cropped.
 * 4. When a C# service creates printable PDFs from EMF drawings and must eliminate extra margins to meet page layout requirements.
 * 5. When a document‑generation workflow requires converting cropped EMF illustrations to PDF to preserve vector quality for downstream editing.
 */