using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output/output.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Assume first page for processing
                CdrImagePage page = (CdrImagePage)cdr.Pages[0];
                page.CacheData();

                // Desired crop size
                int cropWidth = 500;
                int cropHeight = 500;

                // Adjust crop size if image is smaller
                if (cropWidth > page.Width) cropWidth = page.Width;
                if (cropHeight > page.Height) cropHeight = page.Height;

                // Calculate top-left corner for central crop
                int x = (page.Width - cropWidth) / 2;
                int y = (page.Height - cropHeight) / 2;
                if (x < 0) x = 0;
                if (y < 0) y = 0;

                // Perform cropping
                page.Crop(new Rectangle(x, y, cropWidth, cropHeight));

                // Prepare PDF options with rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save cropped page as PDF
                page.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to extract the central 500 × 500 pixels of a CorelDRAW (CDR) illustration and embed it in a PDF report using Aspose.Imaging for .NET.
 * 2. When an application must automatically validate the existence of a CDR file, create missing output folders, and convert the first page to a PDF with default rasterization settings.
 * 3. When a batch‑processing service has to crop the middle region of each CDR document to a fixed size before generating searchable PDF files for archival.
 * 4. When a C# program must handle CDR images that may be smaller than the target crop size, adjust dimensions dynamically, and produce a PDF without manual image editing.
 * 5. When a developer wants to use Aspose.Imaging’s CdrImage and PdfOptions classes to rasterize a CorelDRAW page and save it as a PDF while preserving the original page dimensions.
 */