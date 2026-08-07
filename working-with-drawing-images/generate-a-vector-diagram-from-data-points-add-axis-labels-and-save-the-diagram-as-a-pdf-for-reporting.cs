// HOW-TO: Create PDF Chart with Axes from Data Points in C# (Aspose.Imaging for .NET)
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
            // Output PDF path
            string outputPath = "Output/diagram.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Canvas size
            int width = 600;
            int height = 400;

            // Sample data points
            double[] data = { 10, 20, 15, 30, 25 };

            // Margins
            int leftMargin = 50;
            int rightMargin = 20;
            int topMargin = 20;
            int bottomMargin = 50;

            // Determine scaling
            double minY = double.MaxValue;
            double maxY = double.MinValue;
            foreach (double v in data)
            {
                if (v < minY) minY = v;
                if (v > maxY) maxY = v;
            }
            double yRange = maxY - minY;
            if (yRange == 0) yRange = 1; // avoid division by zero

            double plotHeight = height - topMargin - bottomMargin;
            double plotWidth = width - leftMargin - rightMargin;
            double xStep = plotWidth / (data.Length - 1);
            double yScale = plotHeight / yRange;

            // Create a raster image (PNG) as canvas
            PngOptions pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw axes
                Pen axisPen = new Pen(Color.Black, 2);
                // X axis
                graphics.DrawLine(axisPen,
                    new Point(leftMargin, height - bottomMargin),
                    new Point(width - rightMargin, height - bottomMargin));
                // Y axis
                graphics.DrawLine(axisPen,
                    new Point(leftMargin, topMargin),
                    new Point(leftMargin, height - bottomMargin));

                // Draw data line
                Pen dataPen = new Pen(Color.Blue, 2);
                for (int i = 0; i < data.Length - 1; i++)
                {
                    int x1 = leftMargin + (int)(i * xStep);
                    int y1 = topMargin + (int)((maxY - data[i]) * yScale);
                    int x2 = leftMargin + (int)((i + 1) * xStep);
                    int y2 = topMargin + (int)((maxY - data[i + 1]) * yScale);
                    graphics.DrawLine(dataPen, new Point(x1, y1), new Point(x2, y2));
                }

                // Draw axis labels
                Font labelFont = new Font("Arial", 12);
                using (SolidBrush textBrush = new SolidBrush())
                {
                    textBrush.Color = Color.Black;
                    // X axis label
                    graphics.DrawString("X Axis", labelFont, textBrush, new Point(width / 2, height - bottomMargin + 20));
                    // Y axis label (rotated not required, simple placement)
                    graphics.DrawString("Y Axis", labelFont, textBrush, new Point(leftMargin - 40, topMargin - 10));
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
 * 1. When you need to programmatically generate a line chart from data points and export it as a PDF using Aspose.Imaging for .NET.
 * 2. When you want to visualize sensor measurements or financial figures in a PDF document without relying on external charting libraries, using C# and Aspose.Imaging.
 * 3. When an automated reporting system must create printable diagrams with custom margins, axis scaling, and PDF output based on dynamic data arrays.
 * 4. When you need to embed a generated chart into a PDF invoice or analytics dashboard created on the server side with Aspose.Imaging.
 * 5. When you are building a C# console application that produces PDF graphics for regulatory compliance or archival purposes using Aspose.Imaging.
 */
