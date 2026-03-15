using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class PngToPdfConverter
{
    // Converts all PNG files in the specified input folder to single‑page PDF files
    // in the specified output folder, preserving image fidelity.
    static void Main()
    {
        string inputFolder = @"C:\Images\Png";   // folder containing PNG files
        string outputFolder = @"C:\Images\Pdf";  // folder where PDFs will be saved

        // Ensure the output directory exists
        Directory.CreateDirectory(outputFolder);

        // Get all PNG files in the input directory
        string[] pngFiles = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly);

        // Prepare PDF save options – this tells Aspose.Imaging to render the image as a PDF page
        PdfOptions pdfOptions = new PdfOptions();

        foreach (string pngPath in pngFiles)
        {
            // Load the PNG image (using Aspose.Imaging's built‑in load mechanism)
            using (Image image = Image.Load(pngPath))
            {
                // Build the output PDF file name (same base name, .pdf extension)
                string pdfFileName = Path.GetFileNameWithoutExtension(pngPath) + ".pdf";
                string pdfPath = Path.Combine(outputFolder, pdfFileName);

                // Save the image as a PDF document – each image becomes a single‑page PDF
                // This uses the Save(string, ImageOptionsBase) overload as required by the rules.
                image.Save(pdfPath, pdfOptions);
            }
        }

        Console.WriteLine("Conversion completed. PDFs are located in: " + outputFolder);
    }
}