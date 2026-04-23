using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.psd";
            string outputPath = @"C:\Images\sample.pdf";

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
                // Configure PDF options with high‑quality rasterization settings
                var pdfOptions = new PdfOptions();

                var rasterOptions = new VectorRasterizationOptions
                {
                    // Use a white background for the PDF pages
                    BackgroundColor = Color.White,
                    // Match PDF page size to the source image dimensions
                    PageSize = new Size(image.Width, image.Height),
                    // Optimal smoothing and text rendering for quality
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}