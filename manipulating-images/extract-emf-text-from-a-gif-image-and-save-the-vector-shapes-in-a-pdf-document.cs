// HOW-TO: Convert GIF to Vector PDF via EMF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace EmfFromGifToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputPath = "input.gif";
                string tempEmfPath = "temp.emf";
                string outputPath = "output.pdf";

                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure directories exist for temporary EMF and final PDF
                Directory.CreateDirectory(Path.GetDirectoryName(tempEmfPath) ?? string.Empty);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                // Load GIF and convert to EMF
                using (Image gifImage = Image.Load(inputPath))
                {
                    var emfOptions = new EmfOptions();
                    gifImage.Save(tempEmfPath, emfOptions);
                }

                // Load the generated EMF and save as PDF
                using (Image emfImage = Image.Load(tempEmfPath))
                {
                    var pdfOptions = new PdfOptions();
                    emfImage.Save(outputPath, pdfOptions);
                }

                // Optionally clean up temporary EMF file
                if (File.Exists(tempEmfPath))
                {
                    try
                    {
                        File.Delete(tempEmfPath);
                    }
                    catch
                    {
                        // Ignore any errors during cleanup
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to preserve the quality of animated GIF graphics as scalable vector shapes inside a PDF report.
 * 2. When a legacy workflow requires extracting vector data from GIFs to embed in printable PDF documents.
 * 3. When automating batch conversion of GIF assets to PDF for a documentation pipeline using C# and Aspose.Imaging.
 * 4. When you want to create a PDF that contains editable EMF vector objects generated from GIF images.
 * 5. When cleaning up temporary files after converting GIF to EMF and then to PDF in a server‑side image processing service.
 */
