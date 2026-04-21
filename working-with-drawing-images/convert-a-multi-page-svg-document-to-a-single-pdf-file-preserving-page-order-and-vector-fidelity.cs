using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\multi_page.svg";
        string outputPath = "Output\\result.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG document
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF export options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Export all pages (null means all pages)
                pdfOptions.MultiPageOptions = null;

                // Configure vector rasterization for fidelity
                if (image is VectorImage)
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                }

                // Save as a single PDF preserving page order
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}