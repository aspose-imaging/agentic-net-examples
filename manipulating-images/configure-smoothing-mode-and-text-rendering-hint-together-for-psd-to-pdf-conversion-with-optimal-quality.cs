using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = "Input/sample.psd";
        string outputPath = "Output/output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options with vector rasterization settings for optimal quality
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.AntiAlias,
                    SmoothingMode = SmoothingMode.AntiAlias
                }
            };

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}