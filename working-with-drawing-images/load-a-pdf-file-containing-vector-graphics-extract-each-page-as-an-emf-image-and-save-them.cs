// HOW-TO: Extract PDF Pages as EMF Vector Images Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PDF document
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Ensure output directory exists
                string outputDir = "output";
                Directory.CreateDirectory(outputDir);

                // Cast to multipage interface
                IMultipageImage multipage = pdfImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded PDF is not a multipage image.");
                    return;
                }

                int pageCount = multipage.PageCount;

                // Iterate through each page and save as EMF
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.emf");

                    // Ensure the directory for the output file
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure EMF export options
                    EmfOptions exportOptions = new EmfOptions
                    {
                        // Export only the current page
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1)),
                        // Set vector rasterization options (page size)
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            PageSize = pdfImage.Size
                        }
                    };

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
 * 1. When you need to convert each page of a multi‑page PDF containing vector graphics into separate EMF files for high‑quality printing or inclusion in Microsoft Office documents.
 * 2. When a reporting system must generate scalable vector thumbnails of PDF reports for use in a web portal without losing resolution.
 * 3. When an engineering workflow requires extracting vector drawings from PDF schematics and saving them as EMF to edit later in CAD or Visio.
 * 4. When an automated batch process has to archive PDF pages as EMF assets for long‑term storage while preserving their original vector fidelity.
 * 5. When a document‑conversion service needs to split a PDF into individual EMF pages to feed downstream vector‑based image processing pipelines.
 */
