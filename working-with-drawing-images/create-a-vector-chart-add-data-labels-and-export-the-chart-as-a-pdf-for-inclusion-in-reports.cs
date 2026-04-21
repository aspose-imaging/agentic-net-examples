using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output PDF path (hardcoded)
        string outputPath = @"C:\Temp\Chart.pdf";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define canvas size
        int width = 600;
        int height = 400;

        // Create a raster image (PNG) as a canvas for drawing the chart
        PngOptions pngOptions = new PngOptions();
        using (Image image = Image.Create(pngOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Draw chart axes
            Pen axisPen = new Pen(Color.Black, 2);
            graphics.DrawLine(axisPen, new Point(50, 350), new Point(550, 350)); // X axis
            graphics.DrawLine(axisPen, new Point(50, 350), new Point(50, 50));   // Y axis

            // Sample data values
            int[] values = { 120, 80, 150 };
            string[] labels = { "A", "B", "C" };
            Color[] barColors = { Color.CornflowerBlue, Color.Orange, Color.SeaGreen };

            // Bar dimensions
            int barWidth = 80;
            int spacing = 30;
            int maxBarHeight = 250; // corresponds to max value 150

            // Draw bars and data labels
            for (int i = 0; i < values.Length; i++)
            {
                int barHeight = (int)((values[i] / 150.0) * maxBarHeight);
                int x = 70 + i * (barWidth + spacing);
                int y = 350 - barHeight;

                // Fill bar
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = barColors[i];
                    graphics.FillRectangle(brush, new Rectangle(x, y, barWidth, barHeight));
                }

                // Draw bar outline
                graphics.DrawRectangle(axisPen, new Rectangle(x, y, barWidth, barHeight));

                // Draw data label above bar
                Font labelFont = new Font("Arial", 14);
                using (SolidBrush textBrush = new SolidBrush())
                {
                    textBrush.Color = Color.Black;
                    string valueText = values[i].ToString();
                    // Center the label horizontally on the bar
                    int textX = x + (barWidth / 2) - (valueText.Length * 4);
                    int textY = y - 20;
                    graphics.DrawString(valueText, labelFont, textBrush, new PointF(textX, textY));
                }

                // Draw category label below X axis
                Font catFont = new Font("Arial", 12);
                using (SolidBrush catBrush = new SolidBrush())
                {
                    catBrush.Color = Color.Black;
                    string catText = labels[i];
                    int catX = x + (barWidth / 2) - (catText.Length * 3);
                    int catY = 360;
                    graphics.DrawString(catText, catFont, catBrush, new PointF(catX, catY));
                }
            }

            // Save the drawn image directly as PDF
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}