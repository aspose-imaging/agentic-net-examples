using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input CDR file path
        string inputPath = "input.cdr";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the CDR image using Aspose.Imaging
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Output basic information about the loaded CDR image
            Console.WriteLine($"Loaded CDR image: Width = {cdrImage.Width}, Height = {cdrImage.Height}");

            // Example: export the first page of the CDR document to PDF
            string outputPath = "output\\page0.pdf";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Retrieve the first page
            CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

            // Configure PDF save options with rasterization settings
            PdfOptions pdfOptions = new PdfOptions();
            CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
            {
                PageWidth = page.Width,
                PageHeight = page.Height
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the page as a PDF file
            page.Save(outputPath, pdfOptions);
        }
    }
}