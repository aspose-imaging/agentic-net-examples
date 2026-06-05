using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/output.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Cache data for performance
                cdr.CacheData();

                // Assume first page for cropping
                CdrImagePage page = (CdrImagePage)cdr.Pages[0];
                page.CacheData();

                // Determine central 500x500 rectangle
                int cropWidth = 500;
                int cropHeight = 500;
                int left = (page.Width - cropWidth) / 2;
                int top = (page.Height - cropHeight) / 2;

                // Adjust if image is smaller than the crop size
                if (left < 0) left = 0;
                if (top < 0) top = 0;
                if (cropWidth > page.Width) cropWidth = page.Width;
                if (cropHeight > page.Height) cropHeight = page.Height;

                // Perform cropping
                page.Crop(new Rectangle(left, top, cropWidth, cropHeight));

                // Prepare PDF options with default rasterization settings
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new CdrRasterizationOptions()
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    // Save the cropped page as PDF
                    page.Save(outputPath, pdfOptions);
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
 * 1. When a graphic designer needs to extract a focused 500×500 thumbnail from a CorelDRAW (CDR) illustration and share it as a PDF for client review.
 * 2. When an automated document pipeline must batch‑process CDR files, crop the central region to a fixed size, and generate PDF reports without manual intervention.
 * 3. When a web service receives user‑uploaded CDR artwork and must create a PDF preview that shows only the central portion of the design for faster loading.
 * 4. When a legacy CAD system exports drawings as CDR and a .NET application must convert those drawings into PDF while trimming the edges to meet a printable 500×500 area requirement.
 * 5. When a marketing automation script needs to programmatically rasterize the middle part of a CDR logo and embed it in a PDF brochure using Aspose.Imaging for .NET.
 */