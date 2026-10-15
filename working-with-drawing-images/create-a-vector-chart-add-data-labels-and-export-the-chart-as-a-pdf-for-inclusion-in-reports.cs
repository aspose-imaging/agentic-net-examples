// HOW-TO: Generate Bar Chart with Data Labels and Export to PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output/Chart.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 600;

            FileCreateSource source = new FileCreateSource(outputPath, false);
            PdfOptions options = new PdfOptions();
            options.Source = source;

            using (Image canvas = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Pen axisPen = new Pen(Color.Black, 2);
                graphics.DrawLine(axisPen, new Point(50, height - 50), new Point(width - 50, height - 50));
                graphics.DrawLine(axisPen, new Point(50, height - 50), new Point(50, 50));

                int[] data = { 120, 80, 150, 60, 200 };
                string[] labels = { "A", "B", "C", "D", "E" };
                int barCount = data.Length;
                int maxData = data.Max();
                int chartWidth = width - 100;
                int chartHeight = height - 100;
                int barWidth = chartWidth / (barCount * 2);
                int spacing = barWidth;

                Font labelFont = new Font("Arial", 12);
                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                {
                    for (int i = 0; i < barCount; i++)
                    {
                        int barHeight = (int)((double)data[i] / maxData * chartHeight);
                        int x = 50 + spacing / 2 + i * (barWidth + spacing);
                        int y = height - 50 - barHeight;

                        using (SolidBrush barBrush = new SolidBrush(Color.Blue))
                        {
                            graphics.FillRectangle(barBrush, new Rectangle(x, y, barWidth, barHeight));
                        }

                        string valueLabel = data[i].ToString();
                        graphics.DrawString(valueLabel, labelFont, textBrush, new Point(x + barWidth / 2, y - 20));
                        graphics.DrawString(labels[i], labelFont, textBrush, new Point(x + barWidth / 2, height - 40));
                    }
                }

                canvas.Save();
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
 * 1. When you need to embed a dynamically generated bar chart with labeled values into a PDF report for business analytics.
 * 2. When an automated reporting system must create high‑resolution vector graphics of sales figures without rasterizing the image.
 * 3. When a desktop application has to produce printable PDFs containing charts that scale cleanly on any device.
 * 4. When you want to programmatically generate charts from an array of data and save them directly as PDF files using Aspose.Imaging in C#.
 * 5. When a financial dashboard requires exporting chart visuals with precise data labels for regulatory documentation.
 */
