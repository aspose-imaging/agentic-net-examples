using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF save options with vector rasterization settings
                var pdfOptions = new PdfOptions();

                // Set the text rendering hint to improve readability of embedded fonts
                var vectorOptions = new VectorRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
                };

                pdfOptions.VectorRasterizationOptions = vectorOptions;

                // Save the image as PDF using the configured options
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
 * 1. When a developer needs to convert high‑resolution scanned TIFF invoices into searchable PDF files with crisp, anti‑aliased text for easier reading by accountants.
 * 2. When building a document‑management system that archives legal contracts stored as TIFF images and must render the embedded fonts clearly in PDF for courtroom presentation.
 * 3. When creating a medical imaging workflow that transforms patient record TIFF scans into PDF reports, using Aspose.Imaging’s TextRenderingHint.AntiAlias to ensure legible annotations for clinicians.
 * 4. When developing an e‑learning platform that converts textbook page TIFFs into PDF e‑books, applying vector rasterization options to improve font readability on tablets and e‑readers.
 * 5. When automating the generation of engineering specification sheets from TIFF drawings, configuring the text rendering hint to produce high‑quality PDF documentation for manufacturers.
 */