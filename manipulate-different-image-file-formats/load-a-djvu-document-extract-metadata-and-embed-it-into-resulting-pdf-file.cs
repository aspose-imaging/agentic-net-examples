using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/result.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DjvuImage to access metadata
                DjvuImage djvu = image as DjvuImage;

                // Extract XMP metadata (if any)
                var xmpData = djvu?.XmpData;

                // Prepare PDF options and embed metadata
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.XmpData = xmpData;

                    // Save the document as PDF with embedded metadata
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}