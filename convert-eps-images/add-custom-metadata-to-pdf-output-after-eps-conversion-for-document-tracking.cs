using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/result.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to the specific EPS image type
            var epsImage = image as Aspose.Imaging.FileFormats.Eps.EpsImage;
            if (epsImage == null)
            {
                Console.Error.WriteLine("Loaded image is not an EPS image.");
                return;
            }

            // Configure PDF options with custom metadata
            var pdfOptions = new PdfOptions
            {
                PdfDocumentInfo = new PdfDocumentInfo
                {
                    Title = "Document Title",
                    Author = "Author Name",
                    Subject = "Subject Text",
                    Keywords = "keyword1, keyword2"
                }
            };

            // Save the EPS as PDF with the metadata
            epsImage.Save(outputPath, pdfOptions);
        }
    }
}