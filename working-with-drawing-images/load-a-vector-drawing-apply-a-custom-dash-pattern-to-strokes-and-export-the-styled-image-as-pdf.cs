using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\drawing.svg";
            string outputPath = "Output\\styled.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                // Create PDF options with vector rasterization
                PdfOptions pdfOptions = new PdfOptions();
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };
                pdfOptions.VectorRasterizationOptions = vectorOptions;

                // Create SVG graphics to apply dash pattern
                int width = svgImage.Width;
                int height = svgImage.Height;
                int dpi = 96;

                var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(width, height, dpi);

                // Define a pen with custom dash pattern
                Pen dashPen = new Pen(Color.Black, 2);
                dashPen.DashPattern = new float[] { 5, 3 };

                // Draw a rectangle overlay with dash pattern
                graphics.DrawRectangle(dashPen, 0, 0, width, height);

                // End recording to get a new SVG image
                using (SvgImage styledSvg = graphics.EndRecording())
                {
                    // Save the styled SVG as PDF
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