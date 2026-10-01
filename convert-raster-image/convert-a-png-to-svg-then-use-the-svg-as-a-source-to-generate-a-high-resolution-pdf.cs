// HOW-TO: Convert PNG to SVG and Export High Resolution PDF in C# (Aspose.Imaging for .NET)
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
            string inputPngPath = "Input/input.png";
            string svgPath = "Output/output.svg";
            string pdfPath = "Output/output.pdf";

            if (!File.Exists(inputPngPath))
            {
                Console.Error.WriteLine($"File not found: {inputPngPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(svgPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            using (Image pngImage = Image.Load(inputPngPath))
            {
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    pngImage.Save(svgPath, svgOptions);
                }
            }

            using (Image svgImage = Image.Load(svgPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                    svgImage.Save(pdfPath, pdfOptions);
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
 * 1. When you need to turn a raster PNG logo into a scalable SVG for branding and then embed it in a print‑ready PDF at 300 dpi.
 * 2. When an application must generate vector‑based PDFs from user‑uploaded PNG images for high‑quality reporting.
 * 3. When you want to automate the creation of searchable PDFs by first converting PNG diagrams to SVG vectors and then rendering them at a high resolution.
 * 4. When a web service needs to provide downloadable PDFs that preserve the visual fidelity of PNG assets across different screen sizes.
 * 5. When you are building a batch process that converts a folder of PNG icons into SVG files and then compiles them into a single high‑resolution PDF catalog.
 */
