using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded data points for the diagram
        Point[] dataPoints = new Point[]
        {
            new Point(60, 340),
            new Point(120, 280),
            new Point(180, 220),
            new Point(240, 160),
            new Point(300, 120)
        };

        int canvasWidth = 400;
        int canvasHeight = 400;
        string outputPath = "Output/diagram.pdf";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a raster canvas (PNG options) to draw on
        using (Image canvas = Image.Create(new PngOptions(), canvasWidth, canvasHeight))
        {
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            // Draw X and Y axes
            Pen axisPen = new Pen(Color.Black, 2);
            // X axis
            graphics.DrawLine(axisPen, new Point(40, canvasHeight - 40), new Point(canvasWidth - 20, canvasHeight - 40));
            // Y axis
            graphics.DrawLine(axisPen, new Point(40, canvasHeight - 40), new Point(40, 20));

            // Draw the data line
            Pen dataPen = new Pen(Color.Blue, 2);
            for (int i = 0; i < dataPoints.Length - 1; i++)
            {
                graphics.DrawLine(dataPen, dataPoints[i], dataPoints[i + 1]);
            }

            // Draw markers at each data point
            using (SolidBrush markerBrush = new SolidBrush(Color.Red))
            {
                foreach (Point pt in dataPoints)
                {
                    graphics.FillEllipse(markerBrush, new Rectangle(pt.X - 3, pt.Y - 3, 6, 6));
                }
            }

            // Add axis labels
            Font labelFont = new Font("Arial", 12);
            using (SolidBrush labelBrush = new SolidBrush(Color.Black))
            {
                graphics.DrawString("X Axis", labelFont, labelBrush, new Point(canvasWidth / 2, canvasHeight - 20));
                graphics.DrawString("Y Axis", labelFont, labelBrush, new Point(10, canvasHeight / 2));
            }

            // Save the diagram as PDF
            PdfOptions pdfOptions = new PdfOptions();
            canvas.Save(outputPath, pdfOptions);
        }
    }
}