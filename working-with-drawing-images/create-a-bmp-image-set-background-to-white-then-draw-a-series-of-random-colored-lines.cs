using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\random_lines.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            int width = 800;
            int height = 600;

            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Random rand = new Random();
                int lineCount = 100;

                for (int i = 0; i < lineCount; i++)
                {
                    int r = rand.Next(256);
                    int g = rand.Next(256);
                    int b = rand.Next(256);
                    Color lineColor = Color.FromArgb(255, r, g, b);

                    int x1 = rand.Next(width);
                    int y1 = rand.Next(height);
                    int x2 = rand.Next(width);
                    int y2 = rand.Next(height);

                    Pen pen = new Pen(lineColor, 2);
                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }

                canvas.Save();
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
 * 1. When you need to generate a quick BMP placeholder image with random colored lines for UI layout testing using Aspose.Imaging in C#.
 * 2. When you want to create a simple CAPTCHA‑style image by drawing random colored lines on a white background to help verify human users.
 * 3. When you require a lightweight background texture for a game level or simulation, generated programmatically as a BMP file with random line patterns.
 * 4. When you are benchmarking image rendering performance and need a reproducible BMP file filled with random colored lines to measure processing speed.
 * 5. When you automate the production of decorative line art for reports or presentations, saving the result as a BMP image via C# and Aspose.Imaging.
 */