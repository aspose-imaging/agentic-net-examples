using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputPdfs";

            // List of SVG files to convert
            string[] svgFiles = new[]
            {
                Path.Combine(inputFolder, "illustration1.svg"),
                Path.Combine(inputFolder, "illustration2.svg"),
                Path.Combine(inputFolder, "illustration3.svg")
            };

            foreach (string inputPath in svgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output PDF path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PDF options and embed metadata (using the file name as title)
                    var pdfOptions = new PdfOptions
                    {
                        PdfDocumentInfo = new PdfDocumentInfo
                        {
                            Title = Path.GetFileNameWithoutExtension(inputPath)
                            // Additional metadata fields (Author, Subject, etc.) can be set here if needed
                        }
                    };

                    // Save the image as PDF
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