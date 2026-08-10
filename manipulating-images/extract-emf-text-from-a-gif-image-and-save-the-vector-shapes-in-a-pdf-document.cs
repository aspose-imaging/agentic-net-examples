// HOW-TO: Convert GIF to Vector PDF via EMF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.gif";
            string tempEmfPath = "Output/temp.emf";
            string outputPdfPath = "Output/result.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempEmfPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Convert GIF to EMF with vector rasterization options
            using (Image gif = Image.Load(inputPath))
            {
                var emfRasterOptions = new EmfRasterizationOptions
                {
                    PageSize = gif.Size
                };
                var emfOptions = new EmfOptions
                {
                    VectorRasterizationOptions = emfRasterOptions
                };
                gif.Save(tempEmfPath, emfOptions);
            }

            // Load the generated EMF and save as PDF with vector rasterization options
            using (Image emf = Image.Load(tempEmfPath))
            {
                var pdfVectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = emf.Width,
                    PageHeight = emf.Height
                };
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = pdfVectorOptions
                };
                emf.Save(outputPdfPath, pdfOptions);
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
 * 1. When you need to embed an animated GIF into a PDF as scalable vector shapes for high‑resolution printing.
 * 2. When you must extract vector data from a GIF and save it in a PDF to reduce file size while preserving visual quality.
 * 3. When generating PDF reports that include GIF illustrations and you require them to be vectorized for crisp zoom‑in clarity.
 * 4. When converting legacy GIF assets to PDF format for compliance with document management systems that only accept vector PDFs.
 * 5. When automating a workflow that transforms user‑uploaded GIFs into searchable PDF documents with vector graphics for better accessibility.
 */
