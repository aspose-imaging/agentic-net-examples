using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/result.pdf";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert a large EPS logo into a print‑ready, PDF/A‑2b compliant document by resizing it to a 2000 px width, this Aspose.Imaging for .NET code provides a quick C# solution.
 * 2. When an e‑commerce site must generate uniform product PDFs from vector EPS artwork, scaling each image to a fixed width before exporting to PDF/A‑2b, the snippet handles the resizing and saving automatically.
 * 3. When a document management system requires batch processing of incoming EPS files to standardize their dimensions and archive them as PDF/A‑2b compliant PDFs, developers can embed this resize‑and‑export routine.
 * 4. When a publishing workflow needs to create web‑preview images from EPS illustrations while also delivering a PDF/A‑2b version for legal compliance, the code resizes the EPS and saves it as a compliant PDF in one step.
 * 5. When a GIS application must transform EPS map symbols into a consistent 2000‑pixel width PDF for inclusion in compliance‑checked reports, this C# example performs the necessary image processing and PDF generation.
 */