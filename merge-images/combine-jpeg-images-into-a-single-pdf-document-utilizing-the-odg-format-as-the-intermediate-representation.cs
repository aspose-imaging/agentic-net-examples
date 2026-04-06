using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG file paths
        string[] inputPaths = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Path for the intermediate ODG file
        string odgPath = @"C:\Temp\combined.odg";

        // Ensure the directory for the ODG file exists
        Directory.CreateDirectory(Path.GetDirectoryName(odgPath));

        // Create a multipage ODG image from the JPEG files
        using (Image odgImage = Image.Create(inputPaths))
        {
            // Save the intermediate ODG representation
            odgImage.Save(odgPath);
        }

        // Path for the final PDF output
        string outputPdfPath = @"C:\Output\combined.pdf";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Load the intermediate ODG image
        using (Image odgLoaded = Image.Load(odgPath))
        {
            // Configure PDF options with ODG rasterization settings
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = odgLoaded.Size
                }
            };

            // Save the final PDF document
            odgLoaded.Save(outputPdfPath, pdfOptions);
        }
    }
}