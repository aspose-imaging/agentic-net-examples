// HOW-TO: Generate Bar Chart with Labels and Export to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = Path.Combine("Output", "Chart.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(new PngOptions(), 800, 600))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                int chartX = 100;
                int chartY = 100;
                int chartWidth = 600;
                int chartHeight = 400;

                Aspose.Imaging.Pen axisPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawLine(axisPen, chartX, chartY + chartHeight, chartX + chartWidth, chartY + chartHeight);
                graphics.DrawLine(axisPen, chartX, chartY, chartX, chartY + chartHeight);

                int[] values = { 120, 80, 150, 60, 200 };
                string[] labels = { "A", "B", "C", "D", "E" };
                int barCount = values.Length;
                int maxVal = values.Max();

                int barWidth = chartWidth / (barCount * 2);
                int space = barWidth;

                for (int i = 0; i < barCount; i++)
                {
                    int barHeight = (int)((double)values[i] / maxVal * chartHeight);
                    int x = chartX + space / 2 + i * (barWidth + space);
                    int y = chartY + chartHeight - barHeight;

                    using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                    {
                        graphics.FillRectangle(brush, x, y, barWidth, barHeight);
                    }

                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1);
                    graphics.DrawRectangle(pen, x, y, barWidth, barHeight);

                    Aspose.Imaging.Font valueFont = new Aspose.Imaging.Font("Arial", 12);
                    string valueStr = values[i].ToString();
                    int labelX = x + barWidth / 2 - (valueStr.Length * 3);
                    int labelY = y - 20;
                    using (SolidBrush textBrush = new SolidBrush(Aspose.Imaging.Color.Black))
                    {
                        graphics.DrawString(valueStr, valueFont, textBrush, labelX, labelY);
                    }

                    Aspose.Imaging.Font labelFont = new Aspose.Imaging.Font("Arial", 12);
                    int labelX2 = x + barWidth / 2 - (labels[i].Length * 3);
                    int labelY2 = chartY + chartHeight + 5;
                    using (SolidBrush textBrush2 = new SolidBrush(Aspose.Imaging.Color.Black))
                    {
                        graphics.DrawString(labels[i], labelFont, textBrush2, labelX2, labelY2);
                    }
                }

                image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to programmatically create a bar chart image with data labels and embed it in a PDF report using Aspose.Imaging for .NET.
 * 2. When you want to visualize sales figures or survey results as a vector chart in C# and include the chart in generated PDF documents.
 * 3. When an automated reporting system must generate PDF files that contain custom charts without relying on external design tools.
 * 4. When you are building a desktop application that exports statistical data as high‑resolution PDFs for printing or archiving.
 * 5. When you require a pure .NET solution to draw charts, add annotations, and save them directly to PDF format for compliance documentation.
 */
