// HOW-TO: Convert Multi‑Page PDF Maps to High‑Resolution TIFF Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input PDF path
            string inputPath = "Input\\maps.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PDF document
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Ensure the document is multipage
                IMultipageImage multipage = pdfImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No pages found in PDF.");
                    return;
                }

                // Output directory for TIFF files
                string outputDir = "Output";
                Directory.CreateDirectory(outputDir);

                // Process each page individually
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.tif");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure TIFF export options
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        // Rasterize vector content at original PDF size
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = pdfImage.Width,
                            PageHeight = pdfImage.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        },
                        // Export only the current page
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                    };

                    // Save the current page as a high‑resolution TIFF
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
 * 1. When a GIS analyst needs each page of a vector map PDF as a separate high‑resolution TIFF for raster‑based spatial analysis.
 * 2. When a developer must automate the extraction of individual map sheets from a multi‑page PDF to feed into a legacy imaging system that only accepts TIFF.
 * 3. When a web service generates printable map tiles by converting PDF pages to TIFFs with preserved vector detail at the original size.
 * 4. When a batch job prepares archival copies of engineering drawings by rasterizing each PDF page to lossless TIFF files for long‑term storage.
 * 5. When an application needs to split a PDF containing cadastral maps into separate TIFF images for integration with third‑party GIS software.
 */
