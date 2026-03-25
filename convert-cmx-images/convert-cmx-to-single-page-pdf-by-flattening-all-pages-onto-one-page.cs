using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample_flattened.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX document
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Prepare PDF export options
            var pdfOptions = new PdfOptions
            {
                // Export all pages; they will be rasterized onto a single PDF page
                MultiPageOptions = null,
                // Set rasterization options to flatten vector content
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    // Use the size of the first page as the PDF page size
                    PageWidth = cmxImage.Width,
                    PageHeight = cmxImage.Height,
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                }
            };

            // Save the flattened PDF
            cmxImage.Save(outputPath, pdfOptions);
        }
    }
}