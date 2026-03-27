using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\input\sample.otg";
        string outputPath = @"C:\output\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG → PDF conversion
            OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size,               // Preserve original page size
                BackgroundColor = Color.White        // Optional: set a white background
            };

            // Set up PDF save options and attach the rasterization options
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Font embedding is handled automatically by Aspose.Imaging.
            // If custom fonts are required, configure FontSettings here, e.g.:
            // FontSettings.SetFontsFolder(@"C:\MyFonts");
            // FontSettings.DefaultFontName = "Arial";

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}