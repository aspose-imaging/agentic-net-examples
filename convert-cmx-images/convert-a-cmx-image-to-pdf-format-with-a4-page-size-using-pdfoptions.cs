using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cmx";
        string outputPath = "sample.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options with A4 page size (595x842 points)
            PdfOptions pdfOptions = new PdfOptions
            {
                PageSize = new SizeF(595, 842)
            };

            // Set vector rasterization options for CMX rendering
            pdfOptions.VectorRasterizationOptions = new CmxRasterizationOptions
            {
                PageSize = new SizeF(595, 842),
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}