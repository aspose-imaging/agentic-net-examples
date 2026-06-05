using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = Path.Combine("Output", "composition.pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a PNG canvas in memory
            PngOptions pngOptions = new PngOptions();
            int canvasWidth = 800;
            int canvasHeight = 600;

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Layer 1: Draw a rectangle
                using (SolidBrush brush1 = new SolidBrush())
                {
                    brush1.Color = Color.LightBlue;
                    brush1.Opacity = 100;
                    graphics.FillRectangle(brush1, new Rectangle(50, 50, 300, 200));
                }

                // Layer 2: Draw an ellipse
                using (SolidBrush brush2 = new SolidBrush())
                {
                    brush2.Color = Color.LightCoral;
                    brush2.Opacity = 100;
                    graphics.FillEllipse(brush2, new Rectangle(200, 150, 300, 200));
                }

                // Layer 3: Draw a line
                graphics.DrawLine(new Pen(Color.DarkGreen, 3), new Point(0, 0), new Point(canvasWidth, canvasHeight));

                // Add text annotation for rectangle
                using (SolidBrush textBrush1 = new SolidBrush())
                {
                    textBrush1.Color = Color.Black;
                    textBrush1.Opacity = 100;
                    Font font1 = new Font("Arial", 24);
                    graphics.DrawString("Rectangle Layer", font1, textBrush1, new PointF(60, 40));
                }

                // Add text annotation for ellipse
                using (SolidBrush textBrush2 = new SolidBrush())
                {
                    textBrush2.Color = Color.Black;
                    textBrush2.Opacity = 100;
                    Font font2 = new Font("Arial", 24);
                    graphics.DrawString("Ellipse Layer", font2, textBrush2, new PointF(210, 140));
                }

                // Save the composition as PDF
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
 * 1. When a developer needs to generate a multi‑layer product brochure where each graphic element (rectangle, ellipse, line) is drawn on a PNG canvas, labeled with text, and exported as a PDF using Aspose.Imaging for .NET.
 * 2. When an engineering application must programmatically create annotated schematic diagrams—drawing shapes on separate layers, adding measurement notes, and saving the final composition as a searchable PDF document.
 * 3. When a reporting tool requires dynamic generation of marketing flyers that combine colored shapes, custom fonts, and line art on a raster image and then convert the layout to a PDF for printing or email distribution.
 * 4. When a GIS or mapping service wants to overlay vector graphics such as zones and routes on a base map, annotate each layer with descriptive text, and deliver the map as a PDF file for client review.
 * 5. When an e‑learning platform needs to produce instructional PDFs that illustrate step‑by‑step visuals by programmatically drawing shapes, adding captions, and exporting the assembled page as a PDF using C# and Aspose.Imaging.
 */