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
        string outputPath = @"C:\temp\output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            int width = 400;
            int height = 300;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightBlue);

                // First semi‑transparent rectangle (red)
                using (SolidBrush brush1 = new SolidBrush())
                {
                    brush1.Color = Color.FromArgb(128, 255, 0, 0);
                    brush1.Opacity = 128;
                    graphics.FillRectangle(brush1, new Rectangle(50, 50, 200, 150));
                }

                // Second semi‑transparent rectangle (blue) overlapping the first
                using (SolidBrush brush2 = new SolidBrush())
                {
                    brush2.Color = Color.FromArgb(128, 0, 0, 255);
                    brush2.Opacity = 128;
                    graphics.FillRectangle(brush2, new Rectangle(150, 100, 200, 150));
                }

                // Save the bound image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}