using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Input\sample.odg";
            string outputPath = @"C:\Output\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Optional: set ODG metadata (author and title)
                if (image is OdImage odImage)
                {
                    odImage.Metadata.Title = "Custom Title";
                    odImage.Metadata.Creator = "Custom Author";
                }

                // Configure rasterization options for ODG to PDF conversion
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PDF options and embed custom metadata
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Custom Author",
                        Title = "Custom Title"
                    }
                };

                // Save the image as PDF with the specified options
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}