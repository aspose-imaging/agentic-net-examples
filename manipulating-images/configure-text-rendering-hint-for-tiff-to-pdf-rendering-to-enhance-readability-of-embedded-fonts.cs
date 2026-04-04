using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\input.tif";
        string outputPath = "C:\\temp\\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image tiffImage = Image.Load(inputPath))
        {
            // Configure PDF export options
            var pdfOptions = new PdfOptions();

            // Set up vector rasterization options with enhanced text rendering
            var rasterOptions = new VectorRasterizationOptions
            {
                // Use anti‑aliased text rendering for better readability of embedded fonts
                TextRenderingHint = TextRenderingHint.AntiAlias,
                // Match the PDF page size to the source image size
                PageSize = tiffImage.Size,
                // Optional: set a white background
                BackgroundColor = Color.White
            };

            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as PDF
            tiffImage.Save(outputPath, pdfOptions);
        }
    }
}