using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output paths
            string outputPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "Chart.pdf");
            string outputDir = Path.GetDirectoryName(outputPdfPath);
            Directory.CreateDirectory(outputDir);

            // Canvas size
            int width = 800;
            int height = 600;

            // Create a PNG image as a canvas (temporary, not required to keep)
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(Path.Combine(outputDir, "temp_chart.png"), false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, width, height))
            {
                // Initialize graphics
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw axes
                Aspose.Imaging.Pen axisPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawLine(axisPen, new Aspose.Imaging.Point(50, height - 50), new Aspose.Imaging.Point(width - 50, height - 50)); // X axis
                graphics.DrawLine(axisPen, new Aspose.Imaging.Point(50, height - 50), new Aspose.Imaging.Point(50, 50)); // Y axis

                // Sample data
                int[] values = { 120, 80, 150, 60 };
                string[] labels = { "Q1", "Q2", "Q3", "Q4" };
                int barWidth = 50;
                int gap = 30;
                int maxVal = 200; // for scaling

                // Font for labels
                Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 14);

                for (int i = 0; i < values.Length; i++)
                {
                    int barHeight = (int)((values[i] / (double)maxVal) * (height - 100));
                    int x = 50 + gap + i * (barWidth + gap);
                    int y = height - 50 - barHeight;

                    // Draw bar
                    using (SolidBrush barBrush = new SolidBrush())
                    {
                        barBrush.Color = Aspose.Imaging.Color.Blue;
                        barBrush.Opacity = 100;
                        graphics.FillRectangle(barBrush, new Aspose.Imaging.Rectangle(x, y, barWidth, barHeight));
                    }

                    // Draw value label above bar
                    using (SolidBrush textBrush = new SolidBrush())
                    {
                        textBrush.Color = Aspose.Imaging.Color.Black;
                        textBrush.Opacity = 100;
                        graphics.DrawString(values[i].ToString(), font, textBrush, new Aspose.Imaging.PointF(x, y - 20));
                    }

                    // Draw category label below bar
                    using (SolidBrush textBrush = new SolidBrush())
                    {
                        textBrush.Color = Aspose.Imaging.Color.Black;
                        textBrush.Opacity = 100;
                        graphics.DrawString(labels[i], font, textBrush, new Aspose.Imaging.PointF(x, height - 40));
                    }
                }

                // Save as PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPdfPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}