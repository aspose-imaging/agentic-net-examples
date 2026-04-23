using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file paths (preserve order)
            string[] inputPaths = {
                @"C:\Input\doc1.cdr",
                @"C:\Input\doc2.cdr",
                @"C:\Input\doc3.cdr"
            };

            // Hardcoded output PDF path
            string outputPath = @"C:\Output\Combined.pdf";

            // Validate each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load each CDR document as an Image
            var images = new List<Image>();
            foreach (var inputPath in inputPaths)
            {
                Image img = Image.Load(inputPath);
                images.Add(img);
            }

            // Combine loaded images into a multipage image
            using (Image combined = Image.Create(images.ToArray(), true))
            {
                // Configure PDF options with vector rasterization settings
                var pdfOptions = new PdfOptions();
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save combined PDF
                combined.Save(outputPath, pdfOptions);
            }

            // Dispose individual images
            foreach (var img in images)
            {
                img.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}