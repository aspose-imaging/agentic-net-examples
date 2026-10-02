// HOW-TO: Create BMP Venn Diagram with Overlapping Colored Ellipses in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output\\venn_diagram.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        try
        {
            int width = 500;
            int height = 400;
            BmpOptions bmpOptions = new BmpOptions();

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                using (SolidBrush brush1 = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillEllipse(brush1, 100, 100, 200, 200);
                }

                using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(128, 0, 255, 0)))
                {
                    graphics.FillEllipse(brush2, 200, 100, 200, 200);
                }

                using (SolidBrush brush3 = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                {
                    graphics.FillEllipse(brush3, 150, 180, 200, 200);
                }

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawEllipse(pen, 100, 100, 200, 200);
                graphics.DrawEllipse(pen, 200, 100, 200, 200);
                graphics.DrawEllipse(pen, 150, 180, 200, 200);

                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate a BMP image that visualizes set relationships as a Venn diagram for reports or presentations.
 * 2. When you want to programmatically draw semi‑transparent overlapping circles with custom colors for data visualization in a .NET application.
 * 3. When you need to create a simple bitmap file with outlined ellipses for educational material or tutorials on set theory.
 * 4. When you are building a server‑side service that produces BMP graphics for dynamic charts without relying on external design tools.
 * 5. When you require a reproducible way to export a Venn‑style diagram to BMP format for further processing or printing.
 */
