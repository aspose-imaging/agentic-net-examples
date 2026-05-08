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
        // Hardcoded input and output paths
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/output.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                // Create a graphics object for editing the SVG
                SvgGraphics2D graphics = new SvgGraphics2D(svgImage);

                // Define a custom dash pattern pen
                Pen dashPen = new Pen(Color.Blue, 2);
                dashPen.DashPattern = new float[] { 5, 3 }; // 5 units dash, 3 units gap

                // Example: apply the custom pen to a path covering the whole image.
                // In a real scenario, iterate over existing paths and apply the pen.
                Figure figure = new Figure { IsClosed = true };
                RectangleShape rectShape = new RectangleShape(new RectangleF(0, 0, svgImage.Width, svgImage.Height));
                figure.AddShape(rectShape);
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);
                graphics.DrawPath(dashPen, path);

                // Finalize SVG modifications
                using (SvgImage modifiedSvg = graphics.EndRecording())
                {
                    // Save the styled SVG as PDF
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        modifiedSvg.Save(outputPath, pdfOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}