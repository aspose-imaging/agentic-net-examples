using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\sample.wmf";
            string outputPath = @"C:\Temp\sample.pdf";

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
                // Prepare vector rasterization options to keep the vector data
                var vectorOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure PDF save options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as PDF, preserving scalability
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}