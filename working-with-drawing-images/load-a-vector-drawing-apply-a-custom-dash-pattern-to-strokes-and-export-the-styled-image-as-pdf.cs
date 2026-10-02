// HOW-TO: Apply Custom Dash Pattern To SVG And Export As PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "vector.svg");
            string outputPath = Path.Combine("Output", "styled.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                pen.DashPattern = new float[] { 5, 2 };
                graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(0, 0, image.Width, image.Height));

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
 * 1. When you need to add a dashed border around an entire SVG drawing before delivering it as a PDF report.
 * 2. When you want to programmatically style vector graphics with custom stroke patterns for branding guidelines in a .NET application.
 * 3. When you must convert scalable vector illustrations to printable PDF files while preserving custom line styles.
 * 4. When you are generating automated invoices that include vector logos with a specific dash pattern around the page edges.
 * 5. When you are building a batch process that reads SVG assets, applies consistent stroke styling, and outputs them as PDF for archiving.
 */
