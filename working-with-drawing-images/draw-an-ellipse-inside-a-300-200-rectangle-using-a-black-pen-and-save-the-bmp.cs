// HOW-TO: Create BMP Image With Black Ellipse Inside 300x200 Rectangle In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/ellipse.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 300, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Black);
                Rectangle rect = new Rectangle(0, 0, 300, 200);
                graphics.DrawEllipse(pen, rect);

                image.Save();
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
 * 1. When you need to generate a simple BMP placeholder graphic with a centered ellipse for a report or UI mock‑up in a .NET application.
 * 2. When you want to programmatically create a black‑outlined shape on a white background for printing or archival purposes using Aspose.Imaging.
 * 3. When an automated testing suite requires a consistent 300 × 200 bitmap containing an ellipse to validate image‑processing algorithms.
 * 4. When a desktop application must export a diagram element, such as an ellipse, to BMP format for compatibility with legacy systems.
 * 5. When you are building a batch process that draws basic geometric figures into BMP files for use in documentation or training materials.
 */
