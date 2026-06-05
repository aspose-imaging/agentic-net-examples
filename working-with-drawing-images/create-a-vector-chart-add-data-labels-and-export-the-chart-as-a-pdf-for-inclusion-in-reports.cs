using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output PDF path (hardcoded)
            string outputPath = @"C:\temp\chart.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Chart dimensions
            int width = 800;
            int height = 600;

            // Create a blank raster image (PNG in memory)
            var pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Sample data
                int[] values = { 50, 120, 80, 150, 70 };
                int maxValue = 200; // for scaling

                // Layout settings
                int marginLeft = 80;
                int marginBottom = 80;
                int chartWidth = width - marginLeft - 40;
                int chartHeight = height - 60 - marginBottom;
                int barCount = values.Length;
                int barSpacing = 20;
                int barWidth = (chartWidth - (barSpacing * (barCount + 1))) / barCount;

                // Axes
                Pen axisPen = new Pen(Color.Black, 2);
                graphics.DrawLine(axisPen, new Point(marginLeft, height - marginBottom), new Point(marginLeft + chartWidth, height - marginBottom)); // X axis
                graphics.DrawLine(axisPen, new Point(marginLeft, height - marginBottom), new Point(marginLeft, height - marginBottom - chartHeight)); // Y axis

                // Font for labels
                Font labelFont = new Font("Arial", 12);

                // Draw bars and data labels
                for (int i = 0; i < barCount; i++)
                {
                    int barHeight = (int)((values[i] / (double)maxValue) * chartHeight);
                    int x = marginLeft + barSpacing * (i + 1) + barWidth * i;
                    int y = height - marginBottom - barHeight;

                    // Bar rectangle
                    Rectangle barRect = new Rectangle(x, y, barWidth, barHeight);
                    using (SolidBrush brush = new SolidBrush())
                    {
                        brush.Color = Color.Blue;
                        brush.Opacity = 100;
                        graphics.FillRectangle(brush, barRect);
                    }

                    // Data label above bar
                    string label = values[i].ToString();
                    // Measure string width to center label
                    SizeF labelSize = graphics.MeasureString(label, labelFont, new SizeF(0, 0), null);
                    float labelX = x + (barWidth - labelSize.Width) / 2;
                    float labelY = y - labelSize.Height - 5;
                    using (SolidBrush textBrush = new SolidBrush())
                    {
                        textBrush.Color = Color.Black;
                        textBrush.Opacity = 100;
                        graphics.DrawString(label, labelFont, textBrush, labelX, labelY);
                    }
                }

                // Save as PDF
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate a sales‑by‑region bar chart in C# and embed the chart as a high‑resolution PDF in an automated financial report using Aspose.Imaging.
 * 2. When a developer must create a production‑output histogram with data labels and export it to PDF for inclusion in a weekly operations dashboard.
 * 3. When a developer wants to programmatically draw a student‑grade distribution chart, add numeric labels to each bar, and save the result as a PDF for academic performance summaries.
 * 4. When a developer is required to produce a medical‑test result bar chart with precise scaling and export it as a PDF for patient record documentation.
 * 5. When a developer needs to build a custom KPI bar chart, render it with Aspose.Imaging graphics primitives, and deliver the chart as a PDF attachment in an email‑based business intelligence report.
 */