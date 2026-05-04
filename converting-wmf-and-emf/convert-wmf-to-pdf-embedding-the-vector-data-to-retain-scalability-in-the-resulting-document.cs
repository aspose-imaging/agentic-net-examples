using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample.pdf";

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
                // Configure vector rasterization to preserve vector data
                var vectorOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set PDF options with the vector rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as PDF, retaining scalability
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}