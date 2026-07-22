// HOW-TO: Merge Multiple EMF Files into a Single PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input EMF files
            string[] inputPaths = new[]
            {
                "input1.emf",
                "input2.emf",
                "input3.emf"
            };

            // Hardcoded output PDF file
            string outputPath = "merged.pdf";

            // Validate each input file
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load EMF images
            List<Image> images = new List<Image>();
            foreach (string inputPath in inputPaths)
            {
                Image img = Image.Load(inputPath);
                images.Add(img);
            }

            // Create a multipage image (PDF) from the loaded EMF images
            using (Image pdfDocument = Image.Create(images.ToArray(), true))
            {
                PdfOptions pdfOptions = new PdfOptions();
                pdfDocument.Save(outputPath, pdfOptions);
            }

            // Dispose loaded EMF images
            foreach (Image img in images)
            {
                img.Dispose();
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
 * 1. When you need to combine several vector‑based EMF diagrams into one searchable PDF report without losing quality.
 * 2. When an application must programmatically generate a multi‑page PDF from a collection of Windows Metafile graphics for printing or archiving.
 * 3. When a batch process has to validate the existence of EMF assets, load them, and produce a consolidated PDF for distribution to clients.
 * 4. When you want to preserve the original vector data of engineering schematics while merging them into a single portable document using Aspose.Imaging.
 * 5. When automating the creation of a PDF portfolio that includes multiple EMF charts, ensuring each page retains its scalable resolution in a .NET environment.
 */
