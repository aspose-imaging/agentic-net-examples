using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        // Load the CDR image
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Assume we work with the first page (index 0)
            CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

            // Determine central 500x500 rectangle
            int cropWidth = 500;
            int cropHeight = 500;
            int startX = Math.Max((page.Width - cropWidth) / 2, 0);
            int startY = Math.Max((page.Height - cropHeight) / 2, 0);
            var cropRect = new Rectangle(startX, startY, cropWidth, cropHeight);

            // Crop the page
            page.Crop(cropRect);

            // Prepare PDF save options with default rasterization settings
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = new CdrRasterizationOptions()
            };

            // Save the cropped page as PDF
            page.Save(outputPath, pdfOptions);
        }
    }
}