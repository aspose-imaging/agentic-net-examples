// HOW-TO: Render EPS To High‑Quality PSD With Anti‑Aliasing And Convert To PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.eps";
            string psdPath = "output.psd";
            string pdfPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                };

                var psdOptions = new PsdOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                Directory.CreateDirectory(Path.GetDirectoryName(psdPath));
                image.Save(psdPath, psdOptions);
            }

            using (Image psdImage = Image.Load(psdPath))
            {
                var pdfOptions = new PdfOptions();

                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
                psdImage.Save(pdfPath, pdfOptions);
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
 * 1. When you need to preserve the visual fidelity of vector EPS artwork while converting it to a PSD for further editing in Photoshop, using anti‑alias smoothing and text rendering hints.
 * 2. When you must generate a print‑ready PDF from an EPS source but want to ensure that rasterized layers retain high‑quality rendering by first saving as a PSD.
 * 3. When an automated pipeline processes incoming EPS files and requires consistent anti‑aliased rasterization before delivering PDFs to clients.
 * 4. When you are building a .NET application that converts legacy EPS graphics to modern PDF documents while maintaining crisp text and smooth edges.
 * 5. When you need to batch‑convert multiple EPS files to PDFs and want to intermediate them as PSDs to apply Photoshop‑compatible settings such as smoothing and text rendering.
 */
