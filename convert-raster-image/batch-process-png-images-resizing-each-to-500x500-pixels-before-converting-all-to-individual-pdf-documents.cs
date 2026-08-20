// HOW-TO: Batch Resize PNG Images to 500x500 and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDir, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize the image to 500x500 pixels
                    // The Resize method is part of Aspose.Imaging.Image; using Lanczos resampling for quality
                    image.Resize(500, 500, Aspose.Imaging.ResizeType.LanczosResample);

                    // Prepare PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the resized image as a PDF document
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
 * 1. When you need to generate standardized 500 × 500 PDF thumbnails from a folder of PNG assets for a web catalog.
 * 2. When an automated build process must convert a batch of product PNG images into PDF files with uniform dimensions for printing.
 * 3. When a document management system requires all incoming PNG scans to be resized and stored as PDFs to save storage space.
 * 4. When a reporting tool expects PDF pages of a fixed size and you must preprocess PNG charts by resizing them before conversion.
 * 5. When you are preparing a set of PNG logos for inclusion in a PDF brochure and need each logo to be resized to 500 × 500 pixels automatically.
 */
