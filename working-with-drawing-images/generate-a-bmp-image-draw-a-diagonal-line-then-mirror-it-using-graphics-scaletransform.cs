using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 200;
            int height = 200;

            BmpOptions bmpOptions = new BmpOptions();

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 2);

                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

                graphics.ScaleTransform(-1f, 1f);
                graphics.TranslateTransform(width, 0);

                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

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
 * 1. When a developer needs to generate a BMP thumbnail with a mirrored diagonal line for a Windows desktop widget.
 * 2. When an application must create a simple black‑on‑white test pattern in BMP format to verify printer alignment.
 * 3. When a game engine requires a procedural texture that shows both the original and horizontally flipped diagonal lines for debugging sprite mirroring.
 * 4. When an automated report generator has to embed a BMP illustration of a symmetric design using C# Graphics.ScaleTransform.
 * 5. When a legacy system expects a BMP file containing a mirrored diagonal line to serve as a placeholder image in a UI.
 */