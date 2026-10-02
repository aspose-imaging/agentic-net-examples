// HOW-TO: Create BMP with Ivory Background and Diagonal Hatch Pattern in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/hatch.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.FromArgb(255, 255, 240)); // ivory background

                Pen pen = new Pen(Color.Black, 1);
                int step = 20;

                for (int i = 0; i <= width; i += step)
                {
                    graphics.DrawLine(pen, new Point(i, 0), new Point(width - 1, height - 1 - i));
                    graphics.DrawLine(pen, new Point(0, i), new Point(width - 1 - i, height - 1));
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
 * 1. When you need to generate a lightweight BMP placeholder image with an ivory background for UI mockups.
 * 2. When you want to programmatically add a diagonal hatch texture to a bitmap for printing cross‑hatch shading.
 * 3. When a reporting tool requires a simple patterned background behind charts and you must create it on the fly in C#.
 * 4. When you need to produce a tiled background image for a game level that uses diagonal lines for visual distinction.
 * 5. When an automated document generator must embed a BMP with a custom hatch pattern as a watermark or background element.
 */
