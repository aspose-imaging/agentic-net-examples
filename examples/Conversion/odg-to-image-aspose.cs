using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source ODG file
        string inputPath = @"C:\temp\sample.odg";

        // Desired output files (PNG and PDF in this example)
        string outputPng = @"C:\temp\sample.png";
        string outputPdf = @"C:\temp\sample.pdf";

        // Load the ODG image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options common to both output formats
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                // Set a white background for rasterized pages
                BackgroundColor = Color.White,
                // Preserve the original page size
                PageSize = image.Size
            };

            // ---------- Save as PNG ----------
            PngOptions pngOptions = new PngOptions
            {
                // Attach the rasterization options to the PNG save options
                VectorRasterizationOptions = rasterOptions
            };
            // Perform the save operation
            image.Save(outputPng, pngOptions);

            // ---------- Save as PDF ----------
            PdfOptions pdfOptions = new PdfOptions
            {
                // Attach the same rasterization options to the PDF save options
                VectorRasterizationOptions = rasterOptions
            };
            // Perform the save operation
            image.Save(outputPdf, pdfOptions);
        }
    }
}