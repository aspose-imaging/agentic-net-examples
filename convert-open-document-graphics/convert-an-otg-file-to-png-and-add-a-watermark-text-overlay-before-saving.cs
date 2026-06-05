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
        string inputPath = "input.otg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image otgImage = Image.Load(inputPath))
            {
                int width = otgImage.Width;
                int height = otgImage.Height;

                Source source = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = source };
                Aspose.Imaging.ImageOptions.OtgRasterizationOptions rasterOptions = new Aspose.Imaging.ImageOptions.OtgRasterizationOptions();
                rasterOptions.PageSize = otgImage.Size;
                pngOptions.VectorRasterizationOptions = rasterOptions;

                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    // Draw watermark text at bottom-right corner
                    string watermarkText = "Watermark";
                    Font font = new Font("Arial", 48);
                    SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.White));
                    PointF position = new PointF(width - 250, height - 60);
                    graphics.DrawString(watermarkText, font, brush, position);

                    // Save the bound image
                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}