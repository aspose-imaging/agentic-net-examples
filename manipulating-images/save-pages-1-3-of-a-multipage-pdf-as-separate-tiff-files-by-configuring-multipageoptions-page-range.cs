using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PDF path
            string inputPath = @"C:\Data\input.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory
            string outputDir = @"C:\Data\Output";

            // Load the multipage PDF
            using (Image image = Image.Load(inputPath))
            {
                // Cast to IMultipageImage to access page information
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null || multipage.PageCount < 3)
                {
                    Console.Error.WriteLine("The PDF does not contain at least three pages.");
                    return;
                }

                // Save pages 1‑3 as separate TIFF files
                for (int i = 0; i < 3; i++) // i = 0,1,2 corresponds to pages 1‑3
                {
                    // Prepare TIFF save options with a single page range
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new int[] { i });

                    // Build output file path
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.tif");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the selected page as a TIFF file
                    image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to extract the first three pages of a multi‑page PDF and store each page as an individual TIFF file for archival or printing workflows.
 * 2. When an application must convert selected PDF pages to TIFF to comply with legacy document management systems that only accept TIFF images.
 * 3. When a batch‑processing service has to generate separate high‑resolution TIFFs from a PDF invoice’s first three pages for OCR preprocessing.
 * 4. When a reporting tool requires individual TIFF files for each PDF page to embed them into separate slides or documents.
 * 5. When a developer wants to programmatically split a multi‑page PDF into single‑page TIFFs using C# and Aspose.Imaging’s MultiPageOptions for custom page‑range handling.
 */