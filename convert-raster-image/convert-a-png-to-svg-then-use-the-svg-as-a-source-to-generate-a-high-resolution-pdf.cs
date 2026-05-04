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
            // Hardcoded input and output paths
            string inputPngPath = "Input/image.png";
            string intermediateSvgPath = "Output/image.svg";
            string outputPdfPath = "Output/image.pdf";

            // Validate input PNG exists
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
                var svgRasterOptions = new SvgRasterizationOptions
                {
                    PageSize = pngImage.Size
                };
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = svgRasterOptions
                };
                pngImage.Save(intermediateSvgPath, svgOptions);
            }

            // Validate SVG was created
            if (!File.Exists(intermediateSvgPath))
            {
                Console.Error.WriteLine($"File not found: {intermediateSvgPath}");
                return;
            }

            // Convert SVG to high‑resolution PDF
            using (Image svgImage = Image.Load(intermediateSvgPath))
            {
                var pdfOptions = new PdfOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };
                var pdfRasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                pdfOptions.VectorRasterizationOptions = pdfRasterOptions;

                svgImage.Save(outputPdfPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}