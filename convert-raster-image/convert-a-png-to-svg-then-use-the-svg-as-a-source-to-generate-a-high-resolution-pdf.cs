using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG and output SVG/PDF paths
        string pngPath = "Input/input.png";
        string svgPath = "Output/output.svg";
        string pdfPath = "Output/output.pdf";

        // Verify PNG exists
        if (!File.Exists(pngPath))
        {
            Console.Error.WriteLine($"File not found: {pngPath}");
            return;
        }

        // Ensure output directory exists for SVG
        Directory.CreateDirectory(Path.GetDirectoryName(svgPath));

        // Convert PNG to SVG
        using (Image pngImage = Image.Load(pngPath))
        {
            var svgRasterOptions = new SvgRasterizationOptions
            {
                PageSize = pngImage.Size
            };
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = svgRasterOptions
            };
            pngImage.Save(svgPath, svgOptions);
        }

        // Verify SVG was created
        if (!File.Exists(svgPath))
        {
            Console.Error.WriteLine($"File not found: {svgPath}");
            return;
        }

        // Ensure output directory exists for PDF
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

        // Convert SVG to high‑resolution PDF
        using (Image svgImage = Image.Load(svgPath))
        {
            var pdfRasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White
            };
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = pdfRasterOptions,
                ResolutionSettings = new ResolutionSetting(300, 300)
            };
            svgImage.Save(pdfPath, pdfOptions);
        }
    }
}