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
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.emf");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options with vector rasterization settings
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        // Render text as vector shapes for better quality
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        // Apply smoothing to improve rendering quality
                        SmoothingMode = SmoothingMode.AntiAlias
                    };

                    pdfOptions.VectorRasterizationOptions = vectorOptions;

                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When a developer needs to convert Windows Metafile (EMF) graphics containing text into a high‑quality PDF while preserving the text as scalable vector shapes.
 * 2. When an application must generate printable PDF reports from EMF diagrams and wants anti‑aliased rendering to avoid jagged edges.
 * 3. When a document processing service has to batch‑convert EMF files to PDFs and ensure the output pages match the original image dimensions.
 * 4. When a CAD or engineering tool exports drawings as EMF and the downstream system requires PDF files with a white background and precise vector text rendering.
 * 5. When a web API receives EMF uploads and must return PDF previews with smooth vector rendering for better visual fidelity.
 */