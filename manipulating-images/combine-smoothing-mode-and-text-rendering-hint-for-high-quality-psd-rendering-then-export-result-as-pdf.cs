using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.svg";
        string psdPath = "Output/result.psd";
        string pdfPath = "Output/result.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(psdPath));
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

        // Load the vector image (SVG)
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Configure PSD options with high‑quality rasterization settings
            using (PsdOptions psdOptions = new PsdOptions())
            {
                psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Save as PSD
                svgImage.Save(psdPath, psdOptions);
            }
        }

        // Load the generated PSD and export to PDF
        using (Image psdImage = Image.Load(psdPath))
        {
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                psdImage.Save(pdfPath, pdfOptions);
            }
        }
    }
}