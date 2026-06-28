using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputImages";
            string outputDirectory = @"C:\OutputPdfs";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all .odg and .otg files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in inputFiles)
            {
                string extension = Path.GetExtension(inputPath).ToLowerInvariant();
                if (extension != ".odg" && extension != ".otg")
                    continue; // Skip non-target files

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Choose appropriate rasterization options based on file type
                    VectorRasterizationOptions rasterOptions;
                    if (extension == ".odg")
                    {
                        rasterOptions = new OdgRasterizationOptions
                        {
                            PageSize = image.Size
                        };
                    }
                    else // .otg
                    {
                        rasterOptions = new OtgRasterizationOptions
                        {
                            PageSize = image.Size
                        };
                    }

                    // Set up PDF save options
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as PDF
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
 * 1. When a design studio needs to archive a collection of OpenDocument graphics (.odg) and templates (.otg) as searchable PDF files for client delivery, they can use this C# Aspose.Imaging batch conversion code.
 * 2. When an enterprise document management system must automatically transform mixed ODG and OTG assets into uniformly sized PDF pages for indexing and compliance reporting, the example provides the required C# workflow.
 * 3. When a print shop receives vector drawings in both .odg and .otg formats and wants to generate print‑ready PDFs with consistent page dimensions using Aspose.Imaging in .NET, this code handles the batch processing.
 * 4. When a software vendor wants to add a feature that converts user‑uploaded OpenDocument graphics and templates into PDF previews for web preview thumbnails, the snippet shows how to iterate files and rasterize them in C#.
 * 5. When a legal team needs to batch convert a folder of ODG and OTG evidence files into PDF documents with identical page size for courtroom presentation, the provided C# example automates the conversion using Aspose.Imaging.
 */