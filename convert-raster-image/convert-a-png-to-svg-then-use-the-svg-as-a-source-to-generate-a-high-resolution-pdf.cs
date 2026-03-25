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
        string pngPath = @"C:\Temp\input.png";
        string svgPath = @"C:\Temp\output.svg";
        string pdfPath = @"C:\Temp\output.pdf";

        // Verify PNG input exists
        if (!File.Exists(pngPath))
        {
            Console.Error.WriteLine($"File not found: {pngPath}");
            return;
        }

        // Ensure SVG output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(svgPath));

        // Convert PNG to SVG
        using (Image pngImage = Image.Load(pngPath))
        using (SvgOptions svgOptions = new SvgOptions())
        {
            var svgVectorOptions = new VectorRasterizationOptions();
            svgVectorOptions.PageSize = pngImage.Size;
            svgOptions.VectorRasterizationOptions = svgVectorOptions;

            pngImage.Save(svgPath, svgOptions);
        }

        // Verify SVG output exists
        if (!File.Exists(svgPath))
        {
            Console.Error.WriteLine($"File not found: {svgPath}");
            return;
        }

        // Ensure PDF output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

        // Convert SVG to high‑resolution PDF
        using (Image svgImage = Image.Load(svgPath))
        using (PdfOptions pdfOptions = new PdfOptions())
        {
            var pdfVectorOptions = new VectorRasterizationOptions();
            pdfVectorOptions.PageSize = svgImage.Size;
            pdfOptions.VectorRasterizationOptions = pdfVectorOptions;

            // Set high resolution (e.g., 300 DPI)
            pdfOptions.ResolutionSettings = new ResolutionSetting(300, 300);

            svgImage.Save(pdfPath, pdfOptions);
        }
    }
}