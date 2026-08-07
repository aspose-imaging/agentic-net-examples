using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.pdf";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 600;

            PngOptions pngOptions = new PngOptions();
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 5);
                graphics.DrawRectangle(pen, new Rectangle(100, 100, 200, 150));

                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate a multi‑layer PDF map where each layer is drawn on a raster canvas and labeled with text annotations using Aspose.Imaging for .NET.
 * 2. When an automated reporting system must create a PDF diagram that combines separate graphic layers—such as a background grid, highlighted region, and descriptive labels—by drawing on a PNG raster image and exporting with PdfOptions.
 * 3. When a desktop application wants to produce a printable PDF certificate that includes a drawn border, a logo layer, and personalized name and date text placed on distinct layers using C# graphics operations.
 * 4. When a web API needs to return a PDF brochure that contains layered illustrations (e.g., product silhouette, feature callouts, and caption text) created on a raster image and saved as PDF with Aspose.Imaging.
 * 5. When a document‑generation workflow requires assembling a PDF flyer by stacking multiple graphic layers—each with its own text annotation—on a white canvas before converting the raster image to PDF.
 */