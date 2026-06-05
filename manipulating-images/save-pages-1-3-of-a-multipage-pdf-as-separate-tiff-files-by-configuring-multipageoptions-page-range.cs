using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.pdf";
        string outputDir = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Save pages 1‑3 (indices 0‑2) as separate TIFF files
            for (int i = 0; i < 3; i++)
            {
                string outputPath = Path.Combine(outputDir, $"page{i + 1}.tif");

                // Ensure directory for each output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PDF for each page (isolated load to avoid state issues)
                using (Image pdfImage = Image.Load(inputPath))
                {
                    // Configure TIFF options with MultiPageOptions for a single page
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new int[] { i });

                    // Save the selected page as a TIFF file
                    pdfImage.Save(outputPath, tiffOptions);
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
 * 1. When a legal firm uses C# and Aspose.Imaging for .NET to extract the first three pages of a multi‑page PDF contract and save each page as an individual TIFF file for archival in a document management system.
 * 2. When a medical imaging application leverages Aspose.Imaging’s MultiPageOptions in C# to convert pages 1‑3 of a PDF report into separate TIFF images compatible with legacy PACS viewers.
 * 3. When an e‑commerce platform employs Aspose.Imaging for .NET to generate high‑resolution TIFF thumbnails of the first three pages of a product catalog PDF for print‑ready marketing assets.
 * 4. When an OCR workflow utilizes C# and Aspose.Imaging’s MultiPageOptions to isolate pages 1‑3 of a PDF into separate TIFF files, improving text recognition accuracy per page.
 * 5. When a government agency automates the extraction of the cover sheet and two subsequent pages from a PDF form into distinct TIFF files using Aspose.Imaging for .NET to ensure secure, lossless storage and audit tracking.
 */