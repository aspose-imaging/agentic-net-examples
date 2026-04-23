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
            // Configure vector rasterization to preserve scalability
            var vectorOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set PDF save options with the vector rasterization configuration
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save as PDF, embedding the vector data
            image.Save(outputPath, pdfOptions);
        }
    }
}