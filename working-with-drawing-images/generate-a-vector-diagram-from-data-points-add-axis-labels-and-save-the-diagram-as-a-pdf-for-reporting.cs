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
            string outputPath = "Output/diagram.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 600;

            PngOptions pngOptions = new PngOptions();

            using (Image image = Image.Create(pngOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Axis lines
                Pen axisPen = new Pen(Color.Black, 2);
                // X axis
                graphics.DrawLine(axisPen, new Point(50, height - 50), new Point(width - 50, height - 50));
                // Y axis
                graphics.DrawLine(axisPen, new Point(50, height - 50), new Point(50, 50));

                // Labels
                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                {
                    Font labelFont = new Font("Arial", 16, FontStyle.Regular);
                    graphics.DrawString("X Axis", labelFont, textBrush, new PointF(width - 100, height - 40));
                    graphics.DrawString("Y Axis", labelFont, textBrush, new PointF(10, 30));
                }

                // Sample data points
                double[] dataX = { 0, 1, 2, 3, 4, 5 };
                double[] dataY = { 0, 2, 4, 3, 5, 7 };

                int plotLeft = 50;
                int plotBottom = height - 50;
                int plotRight = width - 50;
                int plotTop = 50;

                double maxX = dataX[dataX.Length - 1];
                double maxY = 7; // maximum Y value for scaling

                double scaleX = (plotRight - plotLeft) / maxX;
                double scaleY = (plotBottom - plotTop) / maxY;

                Pen pointPen = new Pen(Color.Red, 2);
                for (int i = 0; i < dataX.Length - 1; i++)
                {
                    int x1 = plotLeft + (int)(dataX[i] * scaleX);
                    int y1 = plotBottom - (int)(dataY[i] * scaleY);
                    int x2 = plotLeft + (int)(dataX[i + 1] * scaleX);
                    int y2 = plotBottom - (int)(dataY[i + 1] * scaleY);

                    // Draw line between points
                    graphics.DrawLine(pointPen, new Point(x1, y1), new Point(x2, y2));

                    // Draw point marker
                    graphics.DrawEllipse(pointPen, new Rectangle(x1 - 2, y1 - 2, 4, 4));
                }

                // Save as PDF
                image.Save(outputPath, new PdfOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}