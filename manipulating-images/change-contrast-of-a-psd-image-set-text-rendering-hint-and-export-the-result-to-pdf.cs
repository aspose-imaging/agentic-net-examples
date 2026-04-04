using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.psd");
        string outputPath = Path.Combine("Output", "result.pdf");

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
            // Adjust contrast
            RasterImage raster = (RasterImage)image;
            if (!raster.IsCached)
                raster.CacheData();
            raster.AdjustContrast(50f); // Increase contrast

            // Prepare PDF export options with text rendering hint
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                }
            };

            // Save the result as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}