using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\input.wmf";
        string outputPath = @"C:\Temp\output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF export options with vector rasterization to keep scalability
            PdfOptions pdfOptions = new PdfOptions
            {
                // Use WMF rasterization options so the vector data is preserved in the PDF
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}