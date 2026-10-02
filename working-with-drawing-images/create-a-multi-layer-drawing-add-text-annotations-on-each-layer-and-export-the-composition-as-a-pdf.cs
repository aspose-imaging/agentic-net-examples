// HOW-TO: Create Multi‑Layer PNG Composition with Text and Export to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output/composition.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 600;

            using (Image baseImage = Image.Create(new PngOptions(), width, height))
            {
                // Layer 1
                using (Image layer1 = Image.Create(new PngOptions(), width, height))
                {
                    var graphics1 = new Graphics(layer1);
                    graphics1.Clear(Color.White);
                    using (var brush = new SolidBrush(Color.Black))
                    {
                        Font font = new Font("Arial", 48);
                        graphics1.DrawString("Layer 1", font, brush, new Point(100, 100));
                    }
                    ((RasterImage)baseImage).Blend(new Point(0, 0), (RasterImage)layer1, 255);
                }

                // Layer 2
                using (Image layer2 = Image.Create(new PngOptions(), width, height))
                {
                    var graphics2 = new Graphics(layer2);
                    graphics2.Clear(Color.Transparent);
                    using (var brush = new SolidBrush(Color.Red))
                    {
                        Font font = new Font("Arial", 48);
                        graphics2.DrawString("Layer 2", font, brush, new Point(200, 200));
                    }
                    ((RasterImage)baseImage).Blend(new Point(0, 0), (RasterImage)layer2, 255);
                }

                baseImage.Save(outputPath, new PdfOptions());
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
 * 1. Use this code to produce a PDF brochure that overlays multiple PNG layers with text labels for each section.
 * 2. Use it to add separate text watermarks on distinct layers before blending them into a single PDF document.
 * 3. Use it to assemble an invoice by drawing the logo, header, and line‑item details on individual layers and exporting the result as a PDF.
 * 4. Use it to generate personalized certificates where the recipient name and course title are drawn on separate layers and saved as a PDF.
 * 5. Use it to create a CAD‑style preview that renders transparent annotation layers and outputs the combined view as a PDF file.
 */
