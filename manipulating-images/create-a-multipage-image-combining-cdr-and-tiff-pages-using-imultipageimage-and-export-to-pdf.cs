using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string cdrPath = "Input/sample.cdr";
            string tiffPath = "Input/sample.tif";
            string outputPdfPath = "Output/combined.pdf";

            if (!File.Exists(cdrPath))
            {
                Console.Error.WriteLine($"File not found: {cdrPath}");
                return;
            }
            if (!File.Exists(tiffPath))
            {
                Console.Error.WriteLine($"File not found: {tiffPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            using (CdrImage cdrImage = (CdrImage)Image.Load(cdrPath))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffPath))
            {
                Image[] images = new Image[] { cdrImage, tiffImage };
                using (Image pdfDocument = Image.Create(images, true))
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfDocument.Save(outputPdfPath, pdfOptions);
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
 * 1. When a developer must combine a CorelDRAW (CDR) vector page with a scanned TIFF page into a single multipage PDF using Aspose.Imaging’s IMultipageImage for client delivery.
 * 2. When an automated .NET workflow needs to load CDR and TIFF files, create a multipage image with Image.Create, and export it as a PDF for archival purposes.
 * 3. When a printing application has to merge a CDR logo and several TIFF product sheets into one PDF document to streamline the print queue.
 * 4. When a reporting tool generates a PDF that includes both vector diagrams saved as CDR and high‑resolution raster images saved as TIFF, using C# and Aspose.Imaging.
 * 5. When a legal document system must bundle a CDR‑based diagram with TIFF‑scanned signatures into a single PDF for electronic filing.
 */