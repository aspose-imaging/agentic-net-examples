using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input GIF and output PDF paths
            string inputPath = @"C:\Images\input.gif";
            string tempEmfPath = @"C:\Images\temp.emf";
            string outputPath = @"C:\Images\output.pdf";

            // Validate input GIF exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories for temporary EMF and final PDF exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempEmfPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image gifImage = Image.Load(inputPath))
            {
                // Create an EMF canvas with the same dimensions as the GIF
                using (EmfImage emfImage = new EmfImage(gifImage.Width, gifImage.Height))
                {
                    // Draw the GIF onto the EMF canvas
                    Graphics graphics = new Graphics(emfImage);
                    graphics.DrawImage(gifImage, 0, 0);

                    // Save the EMF to a temporary file
                    emfImage.Save(tempEmfPath);
                }
            }

            // Load the generated EMF and save it as PDF (vector shapes preserved)
            using (Image emf = Image.Load(tempEmfPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                emf.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert GIF logos into high‑resolution PDF brochures while preserving vector quality for print, this code renders the GIF onto an EMF canvas and saves it as a PDF.
 * 2. When an application must extract vector outlines from legacy GIF icons to embed them in PDF compliance reports, the snippet creates an EMF intermediate file and writes the vector shapes to PDF.
 * 3. When a web service generates PDF invoices that include company branding stored as GIF images, the code transforms those GIFs into scalable EMF graphics before embedding them in the final PDF.
 * 4. When a desktop tool needs to archive marketing assets by converting GIF banners into searchable PDF files with vector graphics for better indexing, this approach uses Aspose.Imaging to perform the conversion.
 * 5. When a developer is building a batch processing pipeline that normalizes mixed image formats by converting GIF files to vector‑based PDFs for archival storage, the example demonstrates loading the GIF, drawing it to an EMF canvas, and saving the result as a PDF.
 */