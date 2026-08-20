// HOW-TO: How To Convert JPG To PDF With Error Handling In C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.jpg");
            string outputPath = Path.Combine("Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    try
                    {
                        image.Save(outputPath, pdfOptions);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error saving PDF: {ex.Message}");
                        return;
                    }
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
 * 1. When a web application needs to transform user‑uploaded JPEG photos into PDF documents while safely handling missing files or save failures.
 * 2. When an automated batch job processes a folder of images and must create PDFs, ensuring each conversion logs errors without stopping the entire run.
 * 3. When integrating Aspose.Imaging into a desktop tool that generates printable PDFs from screenshots and requires graceful exception reporting to the user.
 * 4. When a cloud service converts product images to PDF catalogs and must capture permission or disk‑space errors during the save operation.
 * 5. When a background service monitors an input directory, converts new JPG files to PDF, and records any failures for later troubleshooting.
 */
