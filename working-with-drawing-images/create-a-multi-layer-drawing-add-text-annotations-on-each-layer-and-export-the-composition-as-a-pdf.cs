// HOW-TO: Create Multi‑Layer PNG Canvas with Text and Export to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output PDF path
            string outputPath = "Output/Composition.pdf";
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary canvas image path (PNG)
            string canvasPath = "Output/Canvas.png";
            Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));

            // Create a PNG canvas with FileCreateSource
            Source canvasSource = new FileCreateSource(canvasPath, false);
            PngOptions pngOptions = new PngOptions { Source = canvasSource };

            // Create canvas of size 800x600
            using (Image canvas = Image.Create(pngOptions, 800, 600))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // ----- Layer 1: Light blue rectangle with text -----
                using (SolidBrush rectBrush = new SolidBrush())
                {
                    rectBrush.Color = Color.LightBlue;
                    rectBrush.Opacity = 100;
                    graphics.FillRectangle(rectBrush, new Rectangle(50, 50, 300, 200));
                }

                Font font1 = new Font("Arial", 24);
                using (SolidBrush textBrush1 = new SolidBrush())
                {
                    textBrush1.Color = Color.Black;
                    textBrush1.Opacity = 100;
                    graphics.DrawString("Layer 1", font1, textBrush1, new Point(60, 60));
                }

                // ----- Layer 2: Light green ellipse with text -----
                using (SolidBrush ellipseBrush = new SolidBrush())
                {
                    ellipseBrush.Color = Color.LightGreen;
                    ellipseBrush.Opacity = 80;
                    graphics.FillEllipse(ellipseBrush, new Rectangle(400, 100, 250, 150));
                }

                Font font2 = new Font("Arial", 24);
                using (SolidBrush textBrush2 = new SolidBrush())
                {
                    textBrush2.Color = Color.DarkGreen;
                    textBrush2.Opacity = 100;
                    graphics.DrawString("Layer 2", font2, textBrush2, new Point(410, 110));
                }

                // Save the canvas to the temporary PNG file
                canvas.Save();
            }

            // Verify the temporary canvas file exists before loading
            if (!File.Exists(canvasPath))
            {
                Console.Error.WriteLine($"File not found: {canvasPath}");
                return;
            }

            // Load the canvas and export as PDF
            using (Image image = Image.Load(canvasPath))
            {
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

/*
 * Real-World Use Cases:
 * 1. When you need to generate a printable report that combines colored shapes and labeled sections, you can programmatically draw the layers and save the result as a PDF.
 * 2. When building a web service that creates custom certificates or badges with background graphics and personalized text, this code lets you compose the image and output a PDF file.
 * 3. When automating the creation of multi‑page marketing flyers where each page is built from layered graphics and annotations, you can use the approach to render each page and export to PDF.
 * 4. When integrating dynamic diagram generation into a desktop application, such as flowcharts with colored nodes and titles, the code produces a high‑resolution PNG canvas and converts it to PDF for sharing.
 * 5. When preparing archival documents that require both vector‑like shapes and searchable text, the layered drawing technique combined with PDF export ensures consistent layout across platforms.
 */
