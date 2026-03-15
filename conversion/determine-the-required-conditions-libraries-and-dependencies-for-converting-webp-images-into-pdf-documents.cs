using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Required conditions:
        // - Input file must be a valid WebP image.
        // - Output path must be writable.
        // Required libraries/dependencies:
        // - Aspose.Imaging (core library)
        // - Aspose.Imaging.ImageOptions (for PdfOptions)
        // - Aspose.Imaging.FileFormats.Webp (implicitly required for WebP support, loaded via Image.Load)

        string inputPath = "input.webp";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Load the WebP image. Image.Load automatically selects the appropriate format handler.
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF options. PdfOptions implements IDisposable, so wrap in using.
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Save the loaded image as a PDF document.
                image.Save(outputPath, pdfOptions);
            }
        }

        Console.WriteLine("WebP to PDF conversion completed successfully.");
    }
}