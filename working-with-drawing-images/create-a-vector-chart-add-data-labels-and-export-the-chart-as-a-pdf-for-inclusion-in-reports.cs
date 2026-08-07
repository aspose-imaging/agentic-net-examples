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
            // Output PDF path (hard‑coded)
            string outputPath = @"C:\Temp\chart.pdf";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a raster image that will hold the chart drawing
            using (Image image = Image.Create(new PngOptions(), 600, 400))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define pens and brushes
                Pen axisPen = new Pen(Aspose.Imaging.Color.Black, 2);
                Pen barPen = new Pen(Aspose.Imaging.Color.Blue, 1);
                using (SolidBrush barBrush = new SolidBrush())
                {
                    barBrush.Color = Aspose.Imaging.Color.Blue;
                    barBrush.Opacity = 100;

                    // Draw X and Y axes
                    graphics.DrawLine(axisPen, new Point(50, 350), new Point(550, 350)); // X‑axis
                    graphics.DrawLine(axisPen, new Point(50, 350), new Point(50, 50));   // Y‑axis

                    // Sample data for the chart
                    int[] values = { 120, 80, 150, 60, 200 };
                    string[] labels = { "A", "B", "C", "D", "E" };
                    int barWidth = 60;
                    int spacing = 20;
                    int maxVal = 200; // maximum value for scaling

                    // Draw bars and data labels
                    for (int i = 0; i < values.Length; i++)
                    {
                        int barHeight = (int)((values[i] / (float)maxVal) * 250);
                        int x = 70 + i * (barWidth + spacing);
                        int y = 350 - barHeight;

                        // Bar rectangle
                        Rectangle barRect = new Rectangle(x, y, barWidth, barHeight);
                        graphics.FillRectangle(barBrush, barRect);
                        graphics.DrawRectangle(barPen, barRect);

                        // Data label above each bar
                        Font labelFont = new Font("Arial", 12);
                        string valueText = values[i].ToString();
                        graphics.DrawString(valueText, labelFont, barBrush, new PointF(x + barWidth / 2 - 10, y - 20));

                        // Category label below each bar
                        graphics.DrawString(labels[i], labelFont, barBrush, new PointF(x + barWidth / 2 - 5, 360));
                    }
                }

                // Save the drawn image as PDF
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
 * 1. When a developer must programmatically draw a bar chart with data labels using Aspose.Imaging in C# and export it as a PDF for inclusion in a quarterly sales performance report.
 * 2. When a financial application needs to create a PNG‑based vector‑style chart of KPI values, add readable labels, and embed the chart in a PDF audit document.
 * 3. When an inventory management system requires generating a visual stock‑level chart on the fly, labeling each bar, and saving the result as a PDF for distribution to warehouse supervisors.
 * 4. When an education platform wants to produce a PDF report card that contains a custom‑drawn bar chart of student test scores with labeled axes using Aspose.Imaging graphics.
 * 5. When a project‑tracking tool needs to render a progress‑status bar chart in C#, annotate each milestone, and export the chart as a PDF to be attached to weekly status emails.
 */