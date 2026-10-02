// HOW-TO: Apply Custom Stroke Dash Pattern to SVG Paths and Export as PDF in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input\\image.svg";
            string outputPath = "Output\\styled.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string svgContent = File.ReadAllText(inputPath);
            string modifiedContent = svgContent.Replace("<path ", "<path stroke-dasharray=\"5,2\" ");

            string tempSvgPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_modified.svg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempSvgPath));
            File.WriteAllText(tempSvgPath, modifiedContent);

            using (Image svgImage = Image.Load(tempSvgPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    };
                    svgImage.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically add a dashed outline to every shape in an SVG before generating a printable PDF report.
 * 2. When a web application must convert user‑uploaded SVG icons into PDFs with consistent stroke styling for branding guidelines.
 * 3. When automating the creation of PDF catalogs that require all vector graphics to share the same custom stroke pattern without manually editing each SVG.
 * 4. When integrating Aspose.Imaging into a C# workflow to ensure SVG diagrams retain a specific dash style when rendered as high‑resolution PDFs for documentation.
 * 5. When batch‑processing multiple SVG files to apply a uniform stroke‑dasharray and export them as PDFs for archival or distribution.
 */
