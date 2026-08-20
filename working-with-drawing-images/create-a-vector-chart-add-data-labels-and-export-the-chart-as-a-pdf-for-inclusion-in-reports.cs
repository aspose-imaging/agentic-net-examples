// HOW-TO: Generate Bar Chart With Data Labels And Export To PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output PDF path
            string outputPath = @"C:\Temp\Chart.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Canvas size
            int canvasWidth = 600;
            int canvasHeight = 400;

            // Create a raster image (PNG) as drawing surface
            PngOptions pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Sample data
                int[] values = { 30, 70, 55, 90, 40 };
                string[] categories = { "A", "B", "C", "D", "E" };
                int maxValue = 100;

                // Chart layout
                int marginLeft = 60;
                int marginBottom = 40;
                int chartWidth = canvasWidth - marginLeft - 20;
                int chartHeight = canvasHeight - 20 - marginBottom;
                int barCount = values.Length;
                int barSpacing = 10;
                int barWidth = (chartWidth - (barSpacing * (barCount + 1))) / barCount;

                // Axes
                Pen axisPen = new Pen(Color.Black, 2);
                graphics.DrawLine(axisPen, new Point(marginLeft, 20), new Point(marginLeft, 20 + chartHeight));
                graphics.DrawLine(axisPen, new Point(marginLeft, 20 + chartHeight), new Point(marginLeft + chartWidth, 20 + chartHeight));

                // Bars and labels
                using (SolidBrush barBrush = new SolidBrush(Color.SkyBlue))
                using (SolidBrush labelBrush = new SolidBrush(Color.Black))
                {
                    Font labelFont = new Font("Arial", 12);
                    for (int i = 0; i < barCount; i++)
                    {
                        int barHeight = (int)((values[i] / (float)maxValue) * chartHeight);
                        int x = marginLeft + barSpacing + i * (barWidth + barSpacing);
                        int y = 20 + chartHeight - barHeight;

                        // Draw bar
                        graphics.FillRectangle(barBrush, new Rectangle(x, y, barWidth, barHeight));

                        // Category label
                        graphics.DrawString(categories[i], labelFont, labelBrush, new PointF(x + barWidth / 2 - 5, 20 + chartHeight + 5));

                        // Data label above bar
                        string dataLabel = values[i].ToString();
                        graphics.DrawString(dataLabel, labelFont, labelBrush, new PointF(x + barWidth / 2 - 5, y - 20));
                    }
                }

                // Save as PDF
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to programmatically create a bar chart with category labels and embed it as a PDF page for automated business reports.
 * 2. When generating performance dashboards that require high‑quality vector graphics exported directly to PDF without using external charting libraries.
 * 3. When building a C# application that must produce printable PDFs containing custom charts for invoices or analytics summaries.
 * 4. When automating the creation of PDF brochures that include statistical bar graphs with clear data labels for marketing materials.
 * 5. When integrating Aspose.Imaging into a data‑processing pipeline to convert raw numeric arrays into PDF charts for compliance documentation.
 */
