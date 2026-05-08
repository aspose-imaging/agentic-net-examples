using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string backgroundPath = "background.bmp";
        string logoPath = "logo.png";
        string outputPath = "output/output.bmp";

        try
        {
            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            {
                using (RasterImage logo = (RasterImage)Image.Load(logoPath))
                {
                    int x = background.Width - logo.Width - 10;
                    int y = background.Height - logo.Height - 10;
                    if (x < 0) x = 0;
                    if (y < 0) y = 0;
                    background.Blend(new Point(x, y), logo, 128);
                }

                var outputSource = new FileCreateSource(outputPath, false);
                var bmpOptions = new BmpOptions() { Source = outputSource };
                background.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}