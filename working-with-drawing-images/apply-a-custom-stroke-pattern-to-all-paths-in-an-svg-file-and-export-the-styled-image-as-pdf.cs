// HOW-TO: Apply Custom Stroke to SVG Paths and Export as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;
                int dpi = 96;

                // Create a new SVG canvas
                var graphics = new SvgGraphics2D(width, height, dpi);

                // Define a custom pen (stroke)
                Aspose.Imaging.Pen customPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                // Custom dash pattern can be set on the pen if needed (e.g., customPen.DashPattern = new float[] {5, 3};)

                // Create a path that covers the whole canvas (example rectangle)
                var path = new Aspose.Imaging.GraphicsPath();
                var figure = new Aspose.Imaging.Figure { IsClosed = true };
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(0, 0, width, height)));
                path.AddFigure(figure);

                // Apply the custom stroke to the path
                graphics.DrawPath(customPen, path);

                // Finalize SVG with the applied styling
                using (SvgImage styledSvg = graphics.EndRecording())
                {
                    // Export the styled SVG as PDF
                    var pdfOptions = new PdfOptions();
                    styledSvg.Save(outputPath, pdfOptions);
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
 * 1. When you need to add a dashed border to every shape in an SVG diagram and deliver the result as a printable PDF using C#.
 * 2. When a reporting tool must programmatically style vector graphics with a specific line thickness before generating PDF reports.
 * 3. When an engineering application requires converting SVG floor plans into PDFs while applying a uniform stroke to highlight walls.
 * 4. When a web service generates custom SVG charts and must embed a consistent stroke style before sending them as PDF attachments.
 * 5. When automating batch processing of SVG assets to ensure all paths have a black 2‑pixel outline and are saved as PDFs for archival.
 */
