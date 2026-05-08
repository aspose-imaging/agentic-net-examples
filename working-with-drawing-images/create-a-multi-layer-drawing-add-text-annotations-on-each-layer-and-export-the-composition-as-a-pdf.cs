using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = Path.Combine("Output", "composition.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a canvas of size 800x600
            PngOptions pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, 800, 600))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Layer 1: LightBlue rectangle with annotation
                using (SolidBrush brush1 = new SolidBrush())
                {
                    brush1.Color = Color.LightBlue;
                    brush1.Opacity = 100;
                    graphics.FillRectangle(brush1, new Rectangle(50, 50, 300, 200));
                }
                graphics.DrawString(
                    "Layer 1",
                    new Font("Arial", 24),
                    new SolidBrush(Color.Black),
                    new PointF(70, 120));

                // Layer 2: LightGreen ellipse with annotation
                using (SolidBrush brush2 = new SolidBrush())
                {
                    brush2.Color = Color.LightGreen;
                    brush2.Opacity = 100;
                    graphics.FillEllipse(brush2, new Rectangle(400, 100, 250, 150));
                }
                graphics.DrawString(
                    "Layer 2",
                    new Font("Arial", 24),
                    new SolidBrush(Color.Black),
                    new PointF(420, 180));

                // Layer 3: LightCoral polygon with annotation
                using (SolidBrush brush3 = new SolidBrush())
                {
                    brush3.Color = Color.LightCoral;
                    brush3.Opacity = 100;
                    Point[] points = new Point[]
                    {
                        new Point(200, 350),
                        new Point(300, 450),
                        new Point(100, 450)
                    };
                    graphics.FillPolygon(brush3, points);
                }
                graphics.DrawString(
                    "Layer 3",
                    new Font("Arial", 24),
                    new SolidBrush(Color.Black),
                    new PointF(150, 400));

                // Export the composition as PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}