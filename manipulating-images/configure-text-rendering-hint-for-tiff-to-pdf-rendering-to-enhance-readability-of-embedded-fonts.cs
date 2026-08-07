using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.tif";
        string outputPath = @"C:\Temp\output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Configure PDF options with vector rasterization settings
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        // Enhance readability of embedded fonts
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
                    }
                };

                // Save the TIFF as PDF using the configured options
                tiffImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert multi‑page TIFF scans of contracts into searchable PDF files while ensuring that any embedded text appears crisp and legible on screen, they can set the TextRenderingHint to AntiAlias as shown.
 * 2. When generating PDF reports from high‑resolution TIFF maps for a GIS application, configuring the text rendering hint improves the readability of map labels and annotations after conversion.
 * 3. When automating the archival of scanned invoices stored as TIFF images into PDF format for an accounting system, applying the AntiAlias rendering hint prevents blurry font rendering in the resulting PDFs.
 * 4. When building a C# service that batches medical record TIFFs into PDF documents for electronic health records, using Aspose.Imaging’s TextRenderingHint ensures that patient information text remains clear for clinicians.
 * 5. When creating a desktop utility that converts TIFF‑based e‑books into PDF while preserving the quality of embedded fonts for e‑readers, setting the TextRenderingHint to AntiAlias enhances the reading experience.
 */