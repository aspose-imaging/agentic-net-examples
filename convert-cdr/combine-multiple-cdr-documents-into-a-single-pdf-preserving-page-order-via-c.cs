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
            // Hardcoded input CDR files
            string[] inputPaths = {
                @"C:\input1.cdr",
                @"C:\input2.cdr",
                @"C:\input3.cdr"
            };

            // Hardcoded output PDF file
            string outputPath = @"C:\output\combined.pdf";

            // Validate each input file
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

            // Create a multipage image from the loaded CDR pages
            using (Image multipage = Image.Create(images.ToArray()))
            {
                // Configure PDF export options with CDR rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the combined PDF
                multipage.Save(outputPath, pdfOptions);
            }

            // Dispose the individual loaded images
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