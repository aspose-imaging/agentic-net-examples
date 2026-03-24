using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the WebP image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Configure PDF options
            using (var pdfOptions = new PdfOptions
            {
                // Set custom page size (A4 in points)
                PageSize = new Aspose.Imaging.SizeF(595f, 842f),
                // Preserve metadata from the source image
                KeepMetadata = true
                // Additional compression settings can be configured via PdfCoreOptions if needed
            })
            {
                // Save as PDF with the specified options
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}