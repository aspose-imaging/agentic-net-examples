using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Configure rasterization options for EMF
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    // Preserve original dimensions
                    PageSize = emfImage.Size,
                    // Apply anti-aliasing for smoother rendering
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    // Optional background color
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // Improve text rendering quality
                rasterOptions.TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias;

                // Set up PDF save options with vector rasterization
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PDF; text will be rendered as vector shapes with smoothing applied
                emfImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}