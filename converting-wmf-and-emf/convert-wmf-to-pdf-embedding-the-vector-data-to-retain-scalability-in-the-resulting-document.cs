using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.wmf");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WMF image and convert to PDF preserving vector data
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Set up vector rasterization options for WMF
            var rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = wmfImage.Size
            };

            // Configure PDF options with the vector rasterization settings
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save as PDF
            wmfImage.Save(outputPath, pdfOptions);
        }
    }
}