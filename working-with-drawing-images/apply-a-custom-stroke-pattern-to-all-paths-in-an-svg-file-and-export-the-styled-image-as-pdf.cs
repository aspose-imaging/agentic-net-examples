using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "input.svg");
        string outputPath = Path.Combine("Output", "output.pdf");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source SVG to obtain its dimensions
        using (Image sourceImage = Image.Load(inputPath))
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            // Create a new SVG canvas with the same size
            int dpi = 96;
            var svgGraphics = new SvgGraphics2D(width, height, dpi);

            // Define a custom pen (stroke pattern can be customized via DashPattern if needed)
            Pen customPen = new Pen(Color.Black, 2);
            // Example for custom dash pattern (uncomment if supported):
            // customPen.DashStyle = DashStyle.Custom;
            // customPen.DashPattern = new float[] { 5, 3 };

            // Create a path consisting of a rectangle shape
            var figure = new Figure { IsClosed = true };
            var path = new GraphicsPath();
            path.AddFigure(figure);
            var rectShape = new RectangleShape(new RectangleF(50, 50, width - 100, height - 100));
            figure.AddShape(rectShape);

            // Draw the path with the custom pen
            svgGraphics.DrawPath(customPen, path);

            // Finalize SVG image
            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                // Prepare PDF export options with vector rasterization
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = width,
                        PageHeight = height
                    }
                };

                // Save the styled SVG as PDF
                svgImage.Save(outputPath, pdfOptions);
            }
        }
    }
}