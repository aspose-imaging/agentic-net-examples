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
            // Hardcoded input PDF path
            string inputPath = "input.pdf";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PDF document
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Verify the document supports multiple pages
                IMultipageImage multipage = pdfImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a multipage vector image.");
                    return;
                }

                int pageCount = multipage.PageCount;
                for (int i = 0; i < pageCount; i++)
                {
                    // Define output EMF file path for each page
                    string outputPath = Path.Combine("output", $"page_{i + 1}.emf");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure EMF export options
                    EmfOptions exportOptions = new EmfOptions
                    {
                        // Export only the current page
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1)),
                        // Set rasterization options for vector rendering
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            PageSize = pdfImage.Size
                        }
                    };

                    // Save the current page as an EMF file
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
 * 1. When a developer needs to convert multi‑page PDF schematics into separate EMF files for high‑quality scaling in Windows desktop applications.
 * 2. When an automated reporting system must extract each page of a vector‑based PDF invoice and store them as EMF images for inclusion in Microsoft Word templates.
 * 3. When a print‑preparation workflow requires converting PDF blueprint pages to EMF to preserve vector data for CAD software that only accepts EMF input.
 * 4. When a document management tool needs to generate thumbnail previews of each PDF page as EMF to maintain crispness at any zoom level in a .NET UI.
 * 5. When a batch processing script must split a vector PDF catalog into individual EMF pages for downstream processing such as watermarking or digital signature overlay.
 */