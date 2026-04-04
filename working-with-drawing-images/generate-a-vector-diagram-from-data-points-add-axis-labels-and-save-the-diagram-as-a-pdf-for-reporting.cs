using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Output PDF path (relative)
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "diagram.pdf");
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Canvas dimensions
        int width = 800;
        int height = 600;

        // Create a raster canvas (PNG options) to draw on
        using (Image canvas = Image.Create(new PngOptions(), width, height))
        {
            // Initialize graphics for the canvas
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            // Margins for the plot area
            int marginLeft = 80;
            int marginRight = 20;
            int marginTop = 20;
            int marginBottom = 50;

            // Draw X and Y axes
            graphics.DrawLine(new Pen(Color.Black, 2),
                new Point(marginLeft, height - marginBottom),
                new Point(width - marginRight, height - marginBottom)); // X axis

            graphics.DrawLine(new Pen(Color.Black, 2),
                new Point(marginLeft, height - marginBottom),
                new Point(marginLeft, marginTop)); // Y axis

            // Sample data points
            double[] dataX = { 0, 1, 2, 3, 4, 5 };
            double[] dataY = { 0, 2, 1, 3, 2, 5 };

            // Determine scaling factors
            double maxX = dataX[dataX.Length - 1];
            double maxY = 5; // maximum Y value (could be computed)

            double plotWidth = width - marginLeft - marginRight;
            double plotHeight = height - marginTop - marginBottom;

            // Draw data points and connecting lines
            using (SolidBrush pointBrush = new SolidBrush(Color.Blue))
            {
                for (int i = 0; i < dataX.Length; i++)
                {
                    int px = marginLeft + (int)(dataX[i] / maxX * plotWidth);
                    int py = height - marginBottom - (int)(dataY[i] / maxY * plotHeight);

                    // Draw point as a small filled circle
                    graphics.FillEllipse(pointBrush, new Rectangle(px - 3, py - 3, 6, 6));

                    // Draw line from previous point
                    if (i > 0)
                    {
                        int prevPx = marginLeft + (int)(dataX[i - 1] / maxX * plotWidth);
                        int prevPy = height - marginBottom - (int)(dataY[i - 1] / maxY * plotHeight);
                        graphics.DrawLine(new Pen(Color.Blue, 1), new Point(prevPx, prevPy), new Point(px, py));
                    }
                }
            }

            // Add axis labels
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            {
                // X‑axis label
                graphics.DrawString("X Axis",
                    new Font("Arial", 14, FontStyle.Regular),
                    textBrush,
                    new PointF(marginLeft + (float)plotWidth / 2 - 30, height - marginBottom + 20));

                // Y‑axis label
                graphics.DrawString("Y Axis",
                    new Font("Arial", 14, FontStyle.Regular),
                    textBrush,
                    new PointF(marginLeft - 60, marginTop + (float)plotHeight / 2));
            }

            // Save the drawing as PDF
            canvas.Save(outputPath, new PdfOptions());
        }
    }
}