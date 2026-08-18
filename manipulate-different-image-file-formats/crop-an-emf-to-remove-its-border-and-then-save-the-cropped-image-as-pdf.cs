// HOW-TO: Crop EMF Image Border and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Temp\input.emf";
        string outputPath = @"C:\Temp\output.pdf";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access cropping functionality
                EmfImage emfImage = (EmfImage)image;

                // Define a rectangle that removes a 10‑pixel border from each side
                int border = 10;
                var cropRect = new Aspose.Imaging.Rectangle(
                    border,
                    border,
                    emfImage.Width - 2 * border,
                    emfImage.Height - 2 * border);

                // Crop the image
                emfImage.Crop(cropRect);

                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Save the cropped image as PDF
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
 * 1. When you need to remove unwanted whitespace from a vector EMF logo before embedding it in a PDF report.
 * 2. When generating printable PDFs from EMF diagrams and you must trim a fixed border to fit page margins.
 * 3. When automating batch conversion of EMF icons to PDF thumbnails and require consistent cropping of each image.
 * 4. When a web service receives EMF files and must deliver a clean PDF version without the original file’s margin artifacts.
 * 5. When integrating Aspose.Imaging in a C# application to preprocess EMF drawings for archival PDFs with precise border removal.
 */
