using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.cmx";
        string outputPath = @"C:\Temp\sample_flattened.pdf";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Calculate combined dimensions of all pages
                int maxWidth = 0;
                int totalHeight = 0;
                foreach (CmxImagePage page in cmxImage.Pages)
                {
                    if (page.Width > maxWidth)
                        maxWidth = page.Width;
                    totalHeight += page.Height;
                }

                // Prepare PDF export options
                var pdfOptions = new PdfOptions
                {
                    // No multipage options – all pages will be rendered onto a single PDF page
                    MultiPageOptions = null,
                    // Set the PDF page size to accommodate all CMX pages
                    PageSize = new SizeF(maxWidth, totalHeight),
                    // Configure vector rasterization to use the combined canvas size
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = maxWidth,
                        PageHeight = totalHeight,
                        BackgroundColor = Aspose.Imaging.Color.White,
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None
                    }
                };

                // Save the flattened PDF
                cmxImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}