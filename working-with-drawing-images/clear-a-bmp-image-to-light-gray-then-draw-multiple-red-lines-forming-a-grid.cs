using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);

                Pen redPen = new Pen(Color.Red, 1);
                int width = image.Width;
                int height = image.Height;

                for (int x = 0; x <= width; x += 50)
                {
                    graphics.DrawLine(redPen, x, 0, x, height);
                }

                for (int y = 0; y <= height; y += 50)
                {
                    graphics.DrawLine(redPen, 0, y, width, y);
                }

                BmpOptions bmpOptions = new BmpOptions();
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
 * 1. When a developer needs to generate a light‑gray BMP template with a red grid overlay for CAD or mapping applications.
 * 2. When a reporting tool must create a printable BMP chart where a uniform grid helps align data points.
 * 3. When a game engine requires a simple BMP texture atlas with visible red grid lines for debugging sprite placement.
 * 4. When an image‑processing pipeline needs to clear an existing BMP image to a neutral color before drawing guide lines for OCR preprocessing.
 * 5. When a desktop utility program wants to convert user‑provided BMP files into a standardized light‑gray background with evenly spaced red lines for visual inspection.
 */