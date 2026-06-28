using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();

                if (image is VectorImage)
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.ClearTypeGridFit,
                        BackgroundColor = Color.White
                    };

                    pdfOptions.VectorRasterizationOptions = vectorOptions;
                }

                image.Save(outputPath, pdfOptions);
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
 * 1. When a designer wants to export a layered Photoshop PSD file to a high‑resolution PDF for client review while preserving vector text crispness using Aspose.Imaging’s SmoothingMode.AntiAlias and TextRenderingHint.ClearTypeGridFit.
 * 2. When an automated build pipeline must convert PSD assets to PDF documents for inclusion in generated technical manuals, ensuring smooth edges and clear text rendering across different platforms.
 * 3. When a web service receives user‑uploaded PSD files and needs to create printable PDFs with a white background and anti‑aliased graphics to meet print‑ready quality standards.
 * 4. When a digital archiving system stores original PSD artwork as PDF snapshots, requiring consistent visual fidelity by applying vector rasterization options such as page size matching, smoothing, and ClearType text rendering.
 * 5. When a desktop application batch‑processes multiple PSD files into PDFs for e‑learning content, using Aspose.Imaging to control smoothing mode and text rendering hint to avoid jagged lines and blurry fonts in the final PDFs.
 */