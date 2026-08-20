// HOW-TO: Batch Convert Raster Images to PDF with Original Filenames in C# (Aspose.Imaging for .NET)
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
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Get all files in the input folder (non-recursive)
            string[] inputFiles = Directory.GetFiles(inputFolder);

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PDF path preserving the original filename
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare default PDF options
                    var pdfOptions = new PdfOptions();

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
 * 1. When you need to generate PDF versions of a set of scanned photos for archiving while keeping each file’s original name.
 * 2. When an application must automatically transform a folder of JPEG or PNG files into PDFs for email attachment without manual conversion.
 * 3. When a document management system requires batch conversion of uploaded raster images to PDF to ensure consistent viewing across devices.
 * 4. When you want to create printable PDFs from a collection of product images for catalog generation while preserving naming for later reference.
 * 5. When a workflow automates the conversion of user‑submitted screenshots into PDFs for compliance reporting, keeping the source filenames intact.
 */
