// HOW-TO: Convert EMF Vector to High Resolution PDF with Embedded Fonts in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.pdf";

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
                // Cast to EmfImage to access size property
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The input file is not a valid EMF image.");
                    return;
                }

                // Configure vector rasterization options for high‑resolution PDF
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = emfImage.Size,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Set up PDF options with the vector rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save the EMF as a PDF with embedded fonts
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
 * 1. When you need to generate printable PDFs from Windows Metafile (EMF) graphics while preserving vector quality and ensuring text appears correctly on any device.
 * 2. When a reporting system must embed fonts in PDF output to avoid missing characters in PDF viewers that lack the original fonts.
 * 3. When an engineering application exports schematics as EMF and requires high‑resolution PDF files for client delivery or archival.
 * 4. When a batch conversion tool processes a folder of EMF icons and creates PDF assets for inclusion in marketing brochures.
 * 5. When a document management workflow converts user‑uploaded EMF files to searchable PDFs with consistent rendering across platforms.
 */
