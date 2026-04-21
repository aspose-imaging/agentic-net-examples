using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputPath = "output.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Define the export rectangle (x, y, width, height)
            var exportArea = new Aspose.Imaging.Rectangle(20, 20, 250, 250);

            // Configure DjVu multi-page options for the first page and the export area
            var djvuOptions = new DjvuMultiPageOptions(0, exportArea);

            // Set up PDF save options with the DjVu multi-page options
            var pdfOptions = new PdfOptions
            {
                MultiPageOptions = djvuOptions
            };

            // Save the specified portion as a PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}