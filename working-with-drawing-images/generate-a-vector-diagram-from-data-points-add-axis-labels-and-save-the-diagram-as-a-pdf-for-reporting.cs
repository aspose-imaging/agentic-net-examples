// HOW-TO: Create Vector Diagram with Axis Labels and Export to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = Path.Combine("Output", "Diagram.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 600;

            SvgOptions svgOptions = new SvgOptions();

            using (Image image = Image.Create(svgOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Axis
                Pen axisPen = new Pen(Color.Black, 2);
                // X axis
                graphics.DrawLine(axisPen, new Point(50, height - 50), new Point(width - 50, height - 50));
                // Y axis
                graphics.DrawLine(axisPen, new Point(50, height - 50), new Point(50, 50));

                // Sample data points
                double[] dataX = { 0, 1, 2, 3, 4, 5 };
                double[] dataY = { 0, 2, 4, 3, 5, 7 };

                // Determine scaling
                double xMin = dataX[0];
                double xMax = dataX[dataX.Length - 1];
                double yMin = dataY[0];
                double yMax = dataY[0];
                foreach (double v in dataY)
                {
                    if (v < yMin) yMin = v;
                    if (v > yMax) yMax = v;
                }

                double plotWidth = width - 100;
                double plotHeight = height - 100;

                double xScale = plotWidth / (xMax - xMin);
                double yScale = plotHeight / (yMax - yMin);

                // Draw data lines
                Pen dataPen = new Pen(Color.Blue, 2);
                for (int i = 0; i < dataX.Length - 1; i++)
                {
                    int x1 = 50 + (int)((dataX[i] - xMin) * xScale);
                    int y1 = height - 50 - (int)((dataY[i] - yMin) * yScale);
                    int x2 = 50 + (int)((dataX[i + 1] - xMin) * xScale);
                    int y2 = height - 50 - (int)((dataY[i + 1] - yMin) * yScale);
                    graphics.DrawLine(dataPen, new Point(x1, y1), new Point(x2, y2));
                }

                // Labels
                Font labelFont = new Font("Arial", 12);
                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                {
                    graphics.DrawString("X Axis", labelFont, textBrush, new Point(width / 2, height - 30));
                    graphics.DrawString("Y Axis", labelFont, textBrush, new Point(10, height / 2));
                }

                // Save as PDF
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = width,
                        PageHeight = height,
                        BackgroundColor = Color.White
                    }
                };
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
 * 1. When you need to generate a scalable chart from numeric data and embed it in a PDF report for business analytics.
 * 2. When you want to automate the creation of engineering diagrams with X‑Y axes and save them as high‑quality PDF files using C#.
 * 3. When a scientific application must plot experimental results as a vector graphic and combine it with other PDF pages for publication.
 * 4. When a financial dashboard requires programmatic rendering of line graphs that can be printed or shared without loss of resolution.
 * 5. When you are building a monitoring tool that exports real‑time sensor readings as SVG charts and converts them to PDF for archival.
 */
