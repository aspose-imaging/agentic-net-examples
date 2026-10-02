// HOW-TO: Create a Traffic Light BMP Image with Three Colored Circles in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/traffic_light.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int radius = 30;
            int diameter = radius * 2;
            int marginX = 10;
            int marginY = 10;
            int spacing = 10;
            int width = marginX * 2 + diameter;
            int height = marginY * 2 + 3 * diameter + 2 * spacing;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.Black);

                int x = marginX;
                int y = marginY;

                using (SolidBrush brushRed = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillEllipse(brushRed, x, y, diameter, diameter);
                }

                y += diameter + spacing;
                using (SolidBrush brushYellow = new SolidBrush(Aspose.Imaging.Color.Yellow))
                {
                    graphics.FillEllipse(brushYellow, x, y, diameter, diameter);
                }

                y += diameter + spacing;
                using (SolidBrush brushGreen = new SolidBrush(Aspose.Imaging.Color.Lime))
                {
                    graphics.FillEllipse(brushGreen, x, y, diameter, diameter);
                }

                Pen pen = new Pen(Aspose.Imaging.Color.White, 2);
                y = marginY;
                for (int i = 0; i < 3; i++)
                {
                    graphics.DrawEllipse(pen, x, y, diameter, diameter);
                    y += diameter + spacing;
                }

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
 * 1. When you need to generate a simple traffic‑light icon as a BMP file for a Windows desktop UI or embedded display without using external graphics tools.
 * 2. When an application must programmatically create status indicators (red, yellow, green) for dashboards or monitoring panels and store them as BMP images for fast loading.
 * 3. When you are building a simulation of road traffic and require lightweight bitmap symbols for vehicles or signals that can be drawn on the fly with Aspose.Imaging in C#.
 * 4. When you want to produce custom icons for printable manuals or documentation where a BMP with solid colored circles is required for compatibility with legacy printers.
 * 5. When an IoT device’s firmware needs to generate a BMP representation of a traffic light for a small screen, using only basic drawing primitives provided by Aspose.Imaging.
 */
