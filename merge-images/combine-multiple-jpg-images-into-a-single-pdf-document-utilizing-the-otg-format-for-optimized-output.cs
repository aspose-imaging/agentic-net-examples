using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hardcoded output PDF file
        string outputPath = @"C:\Output\combined.pdf";

        // Validate each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Configure PDF options with OTG rasterization for optimized output
            var pdfOptions = new PdfOptions();

            var otgRasterization = new OtgRasterizationOptions
            {
                // Use the size of the first page as the target page size
                PageSize = multipageImage.Size
            };

            pdfOptions.VectorRasterizationOptions = otgRasterization;

            // Save the combined PDF
            multipageImage.Save(outputPath, pdfOptions);
        }
    }
}