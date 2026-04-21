using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = "Input/sample.png";
            string psdPath = "Output/result.psd";
            string pdfPath = "Output/result.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(psdPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD options with high‑quality vector rasterization
                using (PsdOptions psdOptions = new PsdOptions())
                {
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias
                    };

                    // Save as PSD
                    image.Save(psdPath, psdOptions);
                }
            }

            // Load the generated PSD
            using (Image psdImage = Image.Load(psdPath))
            {
                // Configure PDF options with the same high‑quality settings
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = psdImage.Width,
                        PageHeight = psdImage.Height,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias
                    };

                    // Save as PDF
                    psdImage.Save(pdfPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}