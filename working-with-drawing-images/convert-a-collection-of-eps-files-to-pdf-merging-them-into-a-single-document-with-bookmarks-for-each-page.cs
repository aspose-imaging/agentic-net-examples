using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input EPS file paths
            string[] inputPaths = new string[]
            {
                "input1.eps",
                "input2.eps",
                "input3.eps"
            };

            // Hardcoded output PDF path
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

            // Load EPS images
            List<Image> images = new List<Image>();
            foreach (string inputPath in inputPaths)
            {
                Image img = Image.Load(inputPath);
                images.Add(img);
            }

            // Create a multipage image from the loaded EPS images
            using (Image result = Image.Create(images.ToArray(), true))
            {
                // Save as a single PDF document
                var pdfOptions = new PdfOptions();
                result.Save(outputPath, pdfOptions);
            }

            // Dispose loaded EPS images
            foreach (var img in images)
            {
                img.Dispose();
            }

            Console.WriteLine("EPS files have been merged into PDF successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a publishing workflow needs to use C# and Aspose.Imaging for .NET to convert a series of EPS artwork files into a single PDF so designers can share one document with each EPS as a separate page.
 * 2. When an engineering team must programmatically merge multiple EPS schematics into one PDF for easy distribution to contractors, using Image.Load and Image.Create in C#.
 * 3. When an e‑learning platform automates the creation of lesson PDFs by combining EPS diagrams into a multipage PDF, enabling page‑level navigation for students.
 * 4. When a legal department requires a .NET solution to archive EPS‑based evidence documents as a consolidated PDF that meets record‑keeping standards.
 * 5. When a desktop application generates printable PDFs from EPS assets, ensuring each vector file appears as an individual page in the final PDF using Aspose.Imaging’s PdfOptions.
 */