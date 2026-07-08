using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base, input and output directories (relative to current directory)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            // Get all BMP files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.bmp");

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Path for the intermediate compressed BMP
                string tempBmpPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + "_compressed.bmp");
                // Ensure the directory for the temporary BMP exists
                Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));

                // Load original BMP and save with specified compression
                using (Image image = Image.Load(inputPath))
                {
                    var bmpOptions = new BmpOptions
                    {
                        Compression = BitmapCompression.Rle8 // Uniform compression level
                    };
                    image.Save(tempBmpPath, bmpOptions);
                }

                // Path for the final PDF output
                string pdfPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                // Ensure the directory for the PDF exists
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                // Load the compressed BMP and convert to PDF
                using (Image compressedImage = Image.Load(tempBmpPath))
                {
                    var pdfOptions = new PdfOptions();
                    compressedImage.Save(pdfPath, pdfOptions);
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
 * 1. When a developer needs to reduce the file size of a large collection of scanned BMP documents before archiving them as searchable PDFs.
 * 2. When an application must prepare BMP screenshots from an automated testing suite for inclusion in a PDF report while ensuring consistent RLE8 compression.
 * 3. When a migration tool converts legacy BMP assets from a manufacturing system into PDF manuals and wants to apply uniform compression to meet storage quotas.
 * 4. When a web service generates PDF invoices from BMP logos and diagrams and must compress the BMPs first to speed up the conversion pipeline.
 * 5. When a desktop utility automates the batch processing of BMP artwork files, compresses them, and bundles each into an individual PDF for client delivery.
 */