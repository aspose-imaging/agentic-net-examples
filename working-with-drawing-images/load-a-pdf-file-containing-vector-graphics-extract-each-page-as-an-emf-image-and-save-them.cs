using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PDF file path
            string inputPath = @"C:\Data\input.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for EMF pages
            string outputDir = @"C:\Data\OutputEmf";

            // Ensure the output directory exists (CreateDirectory works even if the path already exists)
            Directory.CreateDirectory(outputDir);

            // Load the PDF document
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Cast to multipage image to access individual pages
                IMultipageImage multipage = pdfImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("The loaded document does not contain any pages.");
                    return;
                }

                // Iterate through each page and save it as an EMF file
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Prepare EMF export options for the current page
                    EmfOptions exportOptions = new EmfOptions();

                    // Export only the current page (range length = 1)
                    exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                    // Set rasterization options with the original page size
                    exportOptions.VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = pdfImage.Size
                    };

                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.emf");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as EMF
                    pdfImage.Save(outputPath, exportOptions);
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
 * 2. When an automated reporting system must extract vector‑based pages from PDF invoices and store them as EMF images for inclusion in Excel charts.
 * 3. When a document management workflow requires batch conversion of PDF blueprints into EMF format to preserve line art for CAD integration.
 * 4. When a .NET service has to generate printable EMF assets from PDF marketing brochures to maintain crisp vector quality in printed flyers.
 * 5. When a legacy Windows desktop application only accepts EMF files, and a developer must programmatically split a PDF catalog into individual EMF pages for import.
 */