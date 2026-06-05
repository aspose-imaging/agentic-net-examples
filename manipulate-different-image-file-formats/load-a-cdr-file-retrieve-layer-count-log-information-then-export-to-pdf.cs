using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.cdr";
            string outputPath = @"C:\temp\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Cache data for better performance
                image.CacheData();

                // Retrieve and log the number of pages (layers)
                int pageCount = image.PageCount;
                Console.WriteLine($"Cdr file contains {pageCount} page(s).");

                // Export the first page to PDF (adjust index as needed)
                int pageNumber = 0;
                if (pageCount > 0)
                {
                    CdrImagePage page = (CdrImagePage)image.Pages[pageNumber];

                    // Set up PDF export options with rasterization settings
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the page as PDF
                    page.Save(outputPath, pdfOptions);
                    Console.WriteLine($"Page {pageNumber} exported to PDF: {outputPath}");
                }
                else
                {
                    Console.Error.WriteLine("No pages found in the CDR document.");
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
 * 1. When a developer needs to programmatically open a CorelDRAW (CDR) file, determine how many pages or layers it contains, and log that information for validation or reporting purposes.
 * 2. When an application must verify the existence of a CDR source file and automatically create the target directory before processing the image to avoid runtime errors.
 * 3. When a .NET service has to cache CDR image data to improve performance while iterating through its pages for further manipulation.
 * 4. When a workflow requires extracting the first page of a multi‑page CDR document and converting it to a PDF with specific rasterization settings such as text rendering hint and smoothing mode.
 * 5. When a developer wants to automate the conversion of CorelDRAW drawings to PDF format in a batch process, ensuring each output PDF matches the original page dimensions.
 */