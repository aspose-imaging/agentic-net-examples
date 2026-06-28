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
            // Hard‑coded list of TIFF files to process
            string[] inputFiles = {
                @"C:\Images\sample1.tif",
                @"C:\Images\sample2.tif",
                @"C:\Images\sample3.tif"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine the output PDF path (same folder, same name, .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PDF export options with high‑quality smoothing
                    var pdfOptions = new PdfOptions();

                    // Vector rasterization options enable anti‑aliasing (smoothing)
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.AntiAlias,
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    pdfOptions.VectorRasterizationOptions = vectorOptions;

                    // Save the image as a high‑quality PDF
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
 * 1. When a developer needs to convert a batch of multi‑page TIFF scans into high‑resolution PDF documents with anti‑aliasing to preserve text clarity for archiving.
 * 2. When an application must generate printable PDFs from medical imaging TIFF files while ensuring smooth edges and a consistent white background for regulatory compliance.
 * 3. When a document management system requires automated conversion of scanned invoices stored as TIFFs into searchable PDFs with high‑quality smoothing for better OCR results.
 * 4. When a desktop utility processes large sets of architectural blueprint TIFF images into PDF portfolios, using Aspose.Imaging’s VectorRasterizationOptions to maintain line sharpness.
 * 5. When a web service needs to transform user‑uploaded TIFF photos into PDF portfolios with anti‑aliasing to improve visual quality before delivering them to clients.
 */