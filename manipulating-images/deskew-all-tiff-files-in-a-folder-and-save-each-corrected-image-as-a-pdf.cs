// HOW-TO: Deskew TIFF Images And Convert To PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string file in files)
            {
                if (!file.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) && !file.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.NormalizeAngle(false, Color.White);
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
                    }
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
 * 1. When you receive scanned TIFF documents that are slightly rotated and need to be corrected and stored as searchable PDFs for an electronic filing system.
 * 2. When an application must automatically process a folder of multi‑page TIFF invoices, straighten each page, and generate individual PDF files for downstream accounting software.
 * 3. When a document management workflow requires batch deskewing of TIFF blueprints before converting them to PDF for easier viewing and sharing with clients.
 * 4. When a legal firm needs to normalize the orientation of scanned case files in TIFF format and archive them as PDF files using C# and Aspose.Imaging.
 * 5. When a healthcare system must clean up scanned medical records saved as TIFF, remove skew, and convert them to PDF for integration with electronic health record (EHR) platforms.
 */
