using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

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
                // Cast to EmfImage to access cropping functionality
                EmfImage emfImage = (EmfImage)image;

                // Define a rectangle that removes a 10‑pixel border from each side
                int border = 10;
                int cropX = border;
                int cropY = border;
                int cropWidth = emfImage.Width - 2 * border;
                int cropHeight = emfImage.Height - 2 * border;

                // Ensure the rectangle is valid
                if (cropWidth > 0 && cropHeight > 0)
                {
                    var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                    emfImage.Crop(cropRect);
                }

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
 * 1. When a developer needs to strip unwanted white space from a vector‑based EMF diagram before embedding it in a PDF report.
 * 2. When an application must automatically convert legacy Windows Metafile (EMF) logos into PDF thumbnails without the surrounding border.
 * 3. When a batch‑processing tool has to prepare EMF drawings for printing by cropping the edges and saving them as PDF for a print‑ready workflow.
 * 4. When a document‑generation service requires clean‑cropped EMF illustrations to be merged into PDF invoices or contracts.
 * 5. When a migration script converts archived EMF assets to searchable PDF files while removing extra margins to improve layout consistency.
 */