// HOW-TO: Create a Simple House Icon on BMP with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/house.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            bmpOptions.BitsPerPixel = 24;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // House base
                int houseX = 50;
                int houseY = 100;
                int houseWidth = 100;
                int houseHeight = 80;
                using (SolidBrush houseBrush = new SolidBrush(Aspose.Imaging.Color.LightGray))
                {
                    graphics.FillRectangle(houseBrush, houseX, houseY, houseWidth, houseHeight);
                }
                Aspose.Imaging.Pen housePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawRectangle(housePen, houseX, houseY, houseWidth, houseHeight);

                // Roof (triangle)
                Aspose.Imaging.Point[] roofPoints = new Aspose.Imaging.Point[]
                {
                    new Aspose.Imaging.Point(houseX, houseY),
                    new Aspose.Imaging.Point(houseX + houseWidth / 2, houseY - 60),
                    new Aspose.Imaging.Point(houseX + houseWidth, houseY)
                };
                using (SolidBrush roofBrush = new SolidBrush(Aspose.Imaging.Color.Brown))
                {
                    graphics.FillPolygon(roofBrush, roofPoints);
                }
                graphics.DrawPolygon(housePen, roofPoints);

                // Chimney
                int chimneyX = houseX + houseWidth - 30;
                int chimneyY = houseY - 60;
                int chimneyWidth = 20;
                int chimneyHeight = 40;
                using (SolidBrush chimneyBrush = new SolidBrush(Aspose.Imaging.Color.DarkRed))
                {
                    graphics.FillRectangle(chimneyBrush, chimneyX, chimneyY, chimneyWidth, chimneyHeight);
                }
                graphics.DrawRectangle(housePen, chimneyX, chimneyY, chimneyWidth, chimneyHeight);

                // Save the image
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
 * 1. When you need to generate a placeholder house graphic for UI mockups and want to create a BMP file programmatically in C#.
 * 2. When you want to produce a custom icon for real‑estate listings without using external design tools, using Aspose.Imaging drawing primitives.
 * 3. When an application must dynamically create simple vector‑style illustrations such as house symbols for reports or PDFs and store them as BMP images.
 * 4. When you need to automate the creation of basic building diagrams for educational software, leveraging rectangle and polygon drawing in C#.
 * 5. When you require a quick way to render a house silhouette with a chimney for game assets or map markers directly in code.
 */
