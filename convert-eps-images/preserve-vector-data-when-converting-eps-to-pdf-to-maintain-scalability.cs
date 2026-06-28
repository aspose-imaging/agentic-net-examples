using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define relative input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and save as PDF preserving vector data
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
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
 * 1. When a graphic designer needs to embed a scalable logo stored as an EPS file into a PDF brochure without losing vector quality, they can use this C# code to convert EPS to PDF while preserving vector data.
 * 2. When an automated publishing pipeline must batch‑process EPS illustrations into PDF pages for print‑ready output, the Aspose.Imaging code ensures the vector shapes remain editable and resolution‑independent.
 * 3. When a web application generates downloadable PDF reports that include technical diagrams originally created in EPS, developers can call this snippet to keep the diagrams crisp at any zoom level.
 * 4. When a document management system archives engineering drawings saved as EPS and requires them to be viewable in PDF viewers without rasterization, the code provides a reliable C# conversion preserving vector information.
 * 5. When a CAD‑to‑PDF export tool needs to maintain exact line weights and curves from EPS vector files for compliance documentation, this example demonstrates how to load the EPS image and save it as a vector‑based PDF using Aspose.Imaging.
 */