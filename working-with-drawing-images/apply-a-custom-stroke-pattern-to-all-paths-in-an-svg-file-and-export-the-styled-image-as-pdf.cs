using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.svg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "Output/output.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;
                int dpi = 96;

                // Create SVG graphics canvas
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Build a rectangle path
                Figure figure = new Figure { IsClosed = true };
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, width - 100, height - 100)));

                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);

                // Define a custom dash pattern pen
                Pen dashPen = new Pen(Color.Black, 3);
                dashPen.DashStyle = DashStyle.Custom;
                dashPen.DashPattern = new float[] { 5, 3 };

                // Draw the path with the custom stroke
                graphics.DrawPath(dashPen, path);

                // Finalize SVG image
                using (SvgImage resultSvg = graphics.EndRecording())
                {
                    // Export to PDF
                    PdfOptions pdfOptions = new PdfOptions();
                    resultSvg.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate printable engineering diagrams with dashed outlines from SVG schematics, they can apply a custom stroke pattern and export to PDF for high‑resolution printing.
 * 2. When a web application must convert user‑uploaded SVG logos into PDF brochures with consistent dotted borders, this code ensures the stroke style is preserved across all vector paths.
 * 3. When an automated reporting tool has to embed stylized flowcharts into PDF reports, using a custom dash pattern on SVG paths guarantees visual consistency without rasterizing the graphics.
 * 4. When a GIS system exports map layers as SVG and requires a patterned boundary line for land parcels before creating a PDF map sheet, the code provides the needed vector styling.
 * 5. When a branding workflow needs to apply a corporate dash style to all SVG icons and bundle them into a single PDF catalog, this approach automates the stroke styling and format conversion.
 */