// HOW-TO: Increase PSD Image Contrast and Export to PDF with Text Rendering Hint in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage raster)
                {
                    if (!raster.IsCached) raster.CacheData();
                    raster.AdjustContrast(50f);
                }

                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

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
 * 1. When you need to enhance the visual contrast of a Photoshop PSD file before delivering it as a PDF report.
 * 2. When a web service must convert uploaded PSD designs to PDF while ensuring text is rendered with a single‑bit per pixel hint for crisp printing.
 * 3. When an automated batch process has to adjust contrast of multiple PSD assets and generate PDF previews for a digital asset management system.
 * 4. When a desktop application requires saving edited PSD layers as a PDF with specific rasterization options such as no smoothing and a white background.
 * 5. When integrating Aspose.Imaging in a C# workflow to produce PDF documents from PSD files with custom text rendering settings for low‑resolution displays.
 */
