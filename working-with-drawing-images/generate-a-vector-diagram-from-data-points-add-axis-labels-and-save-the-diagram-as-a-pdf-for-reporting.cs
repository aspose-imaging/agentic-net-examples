// HOW-TO: Create a PDF Vector Diagram from Data Points with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output PDF path
            string outputPath = Path.Combine("Output", "diagram.pdf");
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Canvas size
            int width = 800;
            int height = 600;
            int margin = 50;

            // Sample data points
            double[] dataX = { 0, 1, 2, 3, 4, 5 };
            double[] dataY = { 0, 2, 4, 3, 5, 7 };

            // Determine scaling factors
            double maxX = 0;
            double maxY = 0;
            foreach (double v in dataX) if (v > maxX) maxX = v;
            foreach (double v in dataY) if (v > maxY) maxY = v;
            double scaleX = (width - 2 * margin) / maxX;
            double scaleY = (height - 2 * margin) / maxY;

            // Create a raster image canvas
            using (var pngOptions = new PngOptions())
            using (var image = Aspose.Imaging.Image.Create(pngOptions, width, height))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                // Clear background
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw axes
                var axisPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                // X axis
                graphics.DrawLine(axisPen, new Aspose.Imaging.Point(margin, height - margin), new Aspose.Imaging.Point(width - margin, height - margin));
                // Y axis
                graphics.DrawLine(axisPen, new Aspose.Imaging.Point(margin, margin), new Aspose.Imaging.Point(margin, height - margin));

                // Draw data polyline
                var dataPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);
                Aspose.Imaging.Point[] points = new Aspose.Imaging.Point[dataX.Length];
                for (int i = 0; i < dataX.Length; i++)
                {
                    int x = margin + (int)(dataX[i] * scaleX);
                    int y = height - margin - (int)(dataY[i] * scaleY);
                    points[i] = new Aspose.Imaging.Point(x, y);
                }
                graphics.DrawLines(dataPen, points);

                // Axis labels
                using (var textBrush = new SolidBrush(Aspose.Imaging.Color.Black))
                {
                    var font = new Aspose.Imaging.Font("Arial", 16);
                    // X label
                    graphics.DrawString("X Axis", font, textBrush, new Aspose.Imaging.Point(width / 2, height - margin + 20));
                    // Y label (rotated)
                    graphics.DrawString("Y Axis", font, textBrush, new Aspose.Imaging.Point(margin - 30, height / 2));
                }

                // Save as PDF
                using (var pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When you need to programmatically generate a chart for a business report and export it as a PDF file using Aspose.Imaging.
 * 2. When you want to visualize sensor measurements or experiment results in a scalable diagram using Aspose.Imaging instead of third‑party chart libraries.
 * 3. When an automated reporting system must embed custom‑drawn graphics, such as axes and data lines, into PDF documents with Aspose.Imaging.
 * 4. When you have to convert raw numeric arrays into a printable image for compliance documentation or audit trails using Aspose.Imaging.
 * 5. When you are building a C# application that creates PDF graphics on the fly for invoices, dashboards, or scientific papers with Aspose.Imaging.
 */
