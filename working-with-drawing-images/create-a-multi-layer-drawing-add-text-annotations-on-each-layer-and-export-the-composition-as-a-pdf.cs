using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPdfPath = "Output/composition.pdf";
            string tempPngPath = "Output/temp.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            Source pngSource = new FileCreateSource(tempPngPath, false);
            PngOptions pngOptions = new PngOptions() { Source = pngSource };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, 800, 600))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Layer 1: rectangle and annotation
                Pen pen1 = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen1, new Rectangle(50, 50, 300, 200));
                using (SolidBrush brush1 = new SolidBrush())
                {
                    brush1.Color = Color.Blue;
                    brush1.Opacity = 100;
                    Font font1 = new Font("Arial", 24);
                    graphics.DrawString("Layer 1", font1, brush1, new PointF(60, 60));
                }

                // Layer 2: ellipse and annotation
                Pen pen2 = new Pen(Color.Red, 3);
                graphics.DrawEllipse(pen2, new Rectangle(400, 100, 250, 250));
                using (SolidBrush brush2 = new SolidBrush())
                {
                    brush2.Color = Color.Red;
                    brush2.Opacity = 100;
                    Font font2 = new Font("Arial", 24);
                    graphics.DrawString("Layer 2", font2, brush2, new PointF(410, 110));
                }

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    canvas.Save(outputPdfPath, pdfOptions);
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
 * 1. When a developer needs to generate a multi‑layer technical diagram with separate shapes and labels in C# and deliver it as a searchable PDF using Aspose.Imaging.
 * 2. When an application must programmatically create a marketing brochure page that combines colored shapes and promotional text on distinct layers and export the final composition to PDF for printing.
 * 3. When a reporting tool has to embed annotated floor‑plan graphics—such as rooms drawn as rectangles and circles with layer‑specific captions—into a PDF report generated on the fly.
 * 4. When a document‑automation service requires converting dynamically drawn PNG canvases with layered annotations into PDF files for archival or e‑signature workflows.
 * 5. When a developer wants to produce printable certificates that overlay decorative shapes and personalized text on separate layers and save the result as a high‑resolution PDF using Aspose.Imaging for .NET.
 */