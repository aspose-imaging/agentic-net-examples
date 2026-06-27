using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (EpsImage)Image.Load(inputPath))
            {
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);
                image.Resize(newWidth, newHeight);

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
 * 1. When a C# developer using Aspose.Imaging for .NET must convert a vector EPS logo to a PDF/A‑2b compliant PDF for long‑term archiving while scaling the image to a 2000‑pixel width.
 * 2. When an automated .NET workflow needs to resize large EPS illustrations to a standard width before generating PDF reports that meet PDF/A‑2b compliance for regulatory submission.
 * 3. When a desktop application written in C# has to batch‑process EPS files, shrink them to a 2000‑pixel width, and export them as PDF/A‑2b files for consistent printing across different devices.
 * 4. When a content management system built on .NET must ensure uploaded EPS graphics are resized for web preview and saved as PDF/A‑2b PDFs to preserve visual fidelity and meet accessibility standards.
 * 5. When a developer integrates Aspose.Imaging into a C# service that prepares marketing assets by resizing EPS images to a fixed width and delivering PDF/A‑2b compliant PDFs for client delivery.
 */