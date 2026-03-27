using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.djvu";
        string outputPath = "Output\\output.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu document
        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            // Define the export rectangle (x, y, width, height)
            Rectangle exportArea = new Rectangle(20, 20, 250, 250);

            // Configure multi-page options to export the first page with the specified area
            DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(0, exportArea);

            // Set up PDF save options
            PdfOptions pdfOptions = new PdfOptions
            {
                MultiPageOptions = multiPageOptions
            };

            // Save the selected portion as PDF
            djvuImage.Save(outputPath, pdfOptions);
        }
    }
}