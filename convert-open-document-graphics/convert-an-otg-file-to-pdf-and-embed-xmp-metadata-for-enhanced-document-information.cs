using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define base directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Define input and output file paths
        string inputPath = Path.Combine(inputDirectory, "sample.otg");
        string outputPath = Path.Combine(outputDirectory, "sample.pdf");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load OTG image and convert to PDF
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF options
            PdfOptions pdfOptions = new PdfOptions();

            // Configure vector rasterization options
            VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height
            };
            pdfOptions.VectorRasterizationOptions = vectorOptions;

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}