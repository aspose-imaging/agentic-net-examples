using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.cdr";
        string outputPath = @"C:\output\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (CdrImage image = (CdrImage)Image.Load(inputPath))
        {
            // Get the first page (index 0)
            CdrImagePage page = (CdrImagePage)image.Pages[0];

            // Determine crop rectangle (central 500x500 area)
            int cropWidth = 500;
            int cropHeight = 500;
            int x = Math.Max(0, (page.Width - cropWidth) / 2);
            int y = Math.Max(0, (page.Height - cropHeight) / 2);
            int actualWidth = Math.Min(cropWidth, page.Width);
            int actualHeight = Math.Min(cropHeight, page.Height);
            var cropRect = new Rectangle(x, y, actualWidth, actualHeight);

            // Crop the page
            page.Crop(cropRect);

            // Prepare PDF save options
            var pdfOptions = new PdfOptions();
            var rasterOptions = new CdrRasterizationOptions
            {
                PageWidth = page.Width,
                PageHeight = page.Height
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the cropped page as PDF
            page.Save(outputPath, pdfOptions);
        }
    }
}