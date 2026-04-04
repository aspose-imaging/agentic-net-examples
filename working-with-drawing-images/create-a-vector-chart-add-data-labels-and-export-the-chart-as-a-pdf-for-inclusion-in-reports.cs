using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        // Output PDF path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "chart.pdf");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int width = 800;
        int height = 600;

        // Create an in‑memory raster image
        PngOptions pngOptions = new PngOptions();
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, width, height))
        {
            // Initialize graphics
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Draw axes
            Aspose.Imaging.Pen axisPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
            graphics.DrawLine(axisPen, new Aspose.Imaging.Point(50, height - 50), new Aspose.Imaging.Point(width - 50, height - 50)); // X‑axis
            graphics.DrawLine(axisPen, new Aspose.Imaging.Point(50, height - 50), new Aspose.Imaging.Point(50, 50)); // Y‑axis

            // Sample data
            int[] values = { 120, 80, 150, 60, 200 };
            string[] labels = { "A", "B", "C", "D", "E" };
            int maxVal = 0;
            foreach (int v in values) if (v > maxVal) maxVal = v;

            int chartWidth = width - 100;
            int chartHeight = height - 100;
            int barWidth = chartWidth / (values.Length * 2);

            for (int i = 0; i < values.Length; i++)
            {
                int barHeight = (int)((double)values[i] / maxVal * chartHeight);
                int x = 50 + (2 * i + 1) * barWidth;
                int y = height - 50 - barHeight;

                // Draw bar
                using (SolidBrush barBrush = new SolidBrush())
                {
                    barBrush.Color = Aspose.Imaging.Color.Blue;
                    barBrush.Opacity = 100;
                    graphics.FillRectangle(barBrush, new Aspose.Imaging.Rectangle(x, y, barWidth, barHeight));
                }

                // Draw data label
                using (SolidBrush textBrush = new SolidBrush())
                {
                    textBrush.Color = Aspose.Imaging.Color.Black;
                    textBrush.Opacity = 100;
                    Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 14);
                    graphics.DrawString(labels[i], font, textBrush, new Aspose.Imaging.PointF(x + barWidth / 2 - 5, height - 45));
                }
            }

            // Export to PDF
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}