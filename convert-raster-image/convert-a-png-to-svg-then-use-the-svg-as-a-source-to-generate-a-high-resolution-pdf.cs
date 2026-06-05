using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPngPath = "Input/sample.png";
            string intermediateSvgPath = "Output/sample.svg";
            string outputPdfPath = "Output/sample.pdf";

            // Validate input PNG file
            if (!File.Exists(inputPngPath))
            {
                Console.Error.WriteLine($"File not found: {inputPngPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(intermediateSvgPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Convert PNG to SVG
            using (Image pngImage = Image.Load(inputPngPath))
            {
                // Set up SVG export options with rasterization settings
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = pngImage.Size
                    }
                };

                // Save as SVG
                pngImage.Save(intermediateSvgPath, svgOptions);
            }

            // Validate generated SVG file
            if (!File.Exists(intermediateSvgPath))
            {
                Console.Error.WriteLine($"File not found: {intermediateSvgPath}");
                return;
            }

            // Convert SVG to high‑resolution PDF
            using (Image svgImage = Image.Load(intermediateSvgPath))
            {
                PdfOptions pdfOptions = new PdfOptions
                {
                    // Set high DPI for the PDF output
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                // Save as PDF
                svgImage.Save(outputPdfPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}