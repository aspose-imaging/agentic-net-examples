// HOW-TO: Draw Semi Transparent Shapes on BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(stream);
                using (Image image = Image.Create(bmpOptions, 500, 500))
                {
                    Graphics graphics = new Graphics(image);

                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                    {
                        brush.Opacity = 0.5f;
                        graphics.FillRectangle(brush, new Rectangle(50, 50, 200, 150));
                    }

                    using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                    {
                        brush2.Opacity = 0.5f;
                        graphics.FillEllipse(brush2, new Rectangle(150, 100, 200, 150));
                    }

                    image.Save();
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
 * 1. When you need to generate a BMP thumbnail with semi‑transparent overlays for a reporting dashboard.
 * 2. When you want to add a watermark rectangle and ellipse to a BMP image without affecting the original background.
 * 3. When creating custom UI icons in BMP format that require blended shapes for a Windows desktop application.
 * 4. When producing layered graphics for a game asset pipeline where BMP files must retain alpha‑blended shapes.
 * 5. When automating the preparation of printable BMP assets that include translucent highlights for visual emphasis.
 */
