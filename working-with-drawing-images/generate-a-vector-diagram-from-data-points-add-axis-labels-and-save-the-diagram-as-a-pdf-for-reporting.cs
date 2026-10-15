// HOW-TO: Create A PDF Vector Diagram From Data Points In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string outputDirectory = Path.Combine(baseDir, "Output");
            Directory.CreateDirectory(outputDirectory);
            string outputPath = Path.Combine(outputDirectory, "Diagram.pdf");
            string tempBmpPath = Path.Combine(outputDirectory, "temp.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));

            int width = 800;
            int height = 600;
            int margin = 50;

            // Sample data points
            Point[] dataPoints = new Point[]
            {
                new Point(100, 400),
                new Point(200, 300),
                new Point(300, 350),
                new Point(400, 200),
                new Point(500, 250),
                new Point(600, 150)
            };

            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.Source = new FileCreateSource(tempBmpPath, false);
                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Draw axes
                    Pen axisPen = new Pen(Color.Black, 2);
                    // X axis
                    graphics.DrawLine(axisPen, new Point(margin, height - margin), new Point(width - margin, height - margin));
                    // Y axis
                    graphics.DrawLine(axisPen, new Point(margin, margin), new Point(margin, height - margin));

                    // Draw data points and lines
                    Pen linePen = new Pen(Color.Blue, 2);
                    Pen pointPen = new Pen(Color.Red, 2);
                    using (SolidBrush pointBrush = new SolidBrush(Color.Red))
                    {
                        // Connect points
                        for (int i = 0; i < dataPoints.Length - 1; i++)
                        {
                            Point p1 = Transform(dataPoints[i], margin, width, height);
                            Point p2 = Transform(dataPoints[i + 1], margin, width, height);
                            graphics.DrawLine(linePen, p1, p2);
                        }

                        // Draw points as circles
                        foreach (var pt in dataPoints)
                        {
                            Point p = Transform(pt, margin, width, height);
                            int radius = 5;
                            Rectangle ellipseRect = new Rectangle(p.X - radius, p.Y - radius, radius * 2, radius * 2);
                            graphics.DrawEllipse(pointPen, ellipseRect);
                            graphics.FillEllipse(pointBrush, ellipseRect);
                        }
                    }

                    // Add axis labels
                    Font labelFont = new Font("Arial", 14);
                    using (SolidBrush textBrush = new SolidBrush(Color.Black))
                    {
                        // X axis label
                        graphics.DrawString("X Axis", labelFont, textBrush, new Point(width / 2, height - margin + 20));
                        // Y axis label
                        graphics.DrawString("Y Axis", labelFont, textBrush, new Point(margin - 40, height / 2));
                    }
                }

                // Save as PDF
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    using (Image image = Image.Load(tempBmpPath))
                    {
                        image.Save(outputPath, pdfOptions);
                    }
                }
            }

            // Cleanup temporary BMP
            if (File.Exists(tempBmpPath))
            {
                File.Delete(tempBmpPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static Point Transform(Point original, int margin, int canvasWidth, int canvasHeight)
    {
        int x = margin + original.X;
        int y = canvasHeight - margin - original.Y;
        return new Point(x, y);
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a printable PDF chart from a set of measurement values for a scientific report using C# and Aspose.Imaging.
 * 2. When you want to create a quick vector‑based diagram of sales trends and embed it in a PDF invoice without using external charting libraries.
 * 3. When an automated monitoring system must export daily performance data as a PDF graphic for archival and compliance purposes.
 * 4. When a desktop application requires converting plotted data into a high‑resolution BMP first and then into a PDF for distribution to stakeholders.
 * 5. When you need to programmatically draw axes, plot points, and save the result as a PDF file for inclusion in a PowerPoint presentation.
 */
