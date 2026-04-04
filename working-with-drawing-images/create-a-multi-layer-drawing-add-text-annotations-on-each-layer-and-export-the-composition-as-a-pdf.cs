using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define paths
        string canvasPath = "Output/canvas.png";
        string pdfPath = "Output/composition.pdf";

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

        // Create a PNG canvas
        Source canvasSource = new FileCreateSource(canvasPath, false);
        PngOptions pngOptions = new PngOptions { Source = canvasSource };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, 800, 600))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            // Layer 1: rectangle with text
            graphics.DrawRectangle(new Pen(Color.Blue, 3), new Rectangle(50, 50, 300, 200));
            using (SolidBrush brush1 = new SolidBrush(Color.Blue))
            {
                graphics.DrawString("Layer 1", new Font("Arial", 24), brush1, new PointF(60, 60));
            }

            // Layer 2: ellipse with text
            graphics.DrawEllipse(new Pen(Color.Green, 3), new Rectangle(400, 100, 250, 150));
            using (SolidBrush brush2 = new SolidBrush(Color.Green))
            {
                graphics.DrawString("Layer 2", new Font("Arial", 24), brush2, new PointF(410, 110));
            }

            // Layer 3: line with text
            graphics.DrawLine(new Pen(Color.Red, 2), new Point(100, 400), new Point(700, 500));
            using (SolidBrush brush3 = new SolidBrush(Color.Red))
            {
                graphics.DrawString("Layer 3", new Font("Arial", 24), brush3, new PointF(120, 420));
            }

            // Save the canvas image
            canvas.Save();
        }

        // Verify the canvas file exists before converting to PDF
        if (!File.Exists(canvasPath))
        {
            Console.Error.WriteLine($"File not found: {canvasPath}");
            return;
        }

        // Load the canvas and export to PDF
        using (Image image = Image.Load(canvasPath))
        {
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(pdfPath, pdfOptions);
        }
    }
}