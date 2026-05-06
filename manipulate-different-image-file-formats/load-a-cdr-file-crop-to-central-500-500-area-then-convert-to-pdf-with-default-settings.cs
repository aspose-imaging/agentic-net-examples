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

            // Load CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Cache data for performance
                cdr.CacheData();

                // Get the first page (default page)
                CdrImagePage page = (CdrImagePage)cdr.Pages[0];

                // Define central 500x500 crop rectangle
                int cropWidth = 500;
                int cropHeight = 500;
                int x = (page.Width - cropWidth) / 2;
                int y = (page.Height - cropHeight) / 2;
                if (x < 0) x = 0;
                if (y < 0) y = 0;

                // Crop the page
                page.Crop(new Rectangle(x, y, cropWidth, cropHeight));

                // Prepare PDF options with rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the cropped page as PDF
                page.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}