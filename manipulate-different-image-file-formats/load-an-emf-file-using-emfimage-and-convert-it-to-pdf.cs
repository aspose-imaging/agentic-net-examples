using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

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
                // Cast to EmfImage
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not an EMF image.");
                    return;
                }

                // Configure rasterization options for PDF conversion
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size
                };

                // Set PDF save options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PDF
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
 * 1. When a Windows desktop application needs to export vector‑based charts stored as EMF files into printable PDF reports using Aspose.Imaging for .NET.
 * 2. When an automated document generation service must batch‑convert legacy EMF logos into PDF assets for web publishing with C# rasterization options.
 * 3. When a GIS system requires converting map overlays saved in EMF format to PDF for distribution to clients without requiring Windows dependencies.
 * 4. When a cloud‑based API receives user‑submitted EMF drawings and must return a PDF version for email attachment or download.
 * 5. When a migration tool moves design assets from the old Windows Enhanced Metafile (EMF) format to a cross‑platform PDF portfolio for long‑term archival.
 */