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
            // Hard‑coded input PDF file
            string inputPath = @"C:\Input\sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Directory where the EMF pages will be saved
            string outputDirectory = @"C:\Output";

            // Load the PDF document (vector image)
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Ensure the document supports multiple pages
                if (pdfImage is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    int pageCount = multipage.PageCount;

                    for (int i = 0; i < pageCount; i++)
                    {
                        // Build the output file name for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.emf");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure EMF export options for a single page
                        var emfOptions = new EmfOptions
                        {
                            // Export only the current page (range start, length = 1)
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, 1)),
                            // Set rasterization options so the page size matches the source
                            VectorRasterizationOptions = new EmfRasterizationOptions
                            {
                                PageSize = pdfImage.Size
                            }
                        };

                        // Save the current page as an EMF file
                        pdfImage.Save(outputPath, emfOptions);
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded document does not contain multiple pages.");
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
 * 1. When a developer needs to convert each page of a multi‑page PDF containing vector graphics into separate EMF files for high‑quality scaling in Windows applications.
 * 2. When an automated reporting system must extract vector‑based pages from a PDF invoice and save them as EMF images for embedding in Word documents.
 * 3. When a batch‑processing tool has to rasterize PDF pages to EMF format to preserve vector data for later editing in Adobe Illustrator or CorelDRAW.
 * 4. When a print‑preparation workflow requires converting PDF pages to EMF to ensure resolution‑independent rendering on printers that accept EMF input.
 * 5. When a migration script must archive each page of a PDF blueprint as an individual EMF file to maintain compatibility with legacy .NET imaging components.
 */