using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.odg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Step 1: Rasterize ODG to a temporary PNG
            string tempPath = "temp.png";
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            using (Image odgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        PageSize = odgImage.Size,
                        BackgroundColor = Color.White
                    }
                };
                odgImage.Save(tempPath, pngOptions);
            }

            // Step 2: Load the rasterized PNG, add watermark text, and save final PNG
            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                Graphics graphics = new Graphics(raster);

                string watermarkText = "Sample Watermark";
                Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 48);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                {
                    // Position the watermark near the bottom-left corner
                    int x = 10;
                    int y = raster.Height - 60;
                    graphics.DrawString(watermarkText, font, brush, new Point(x, y));
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                raster.Save(outputPath, new PngOptions());
            }

            // Clean up temporary file
            if (File.Exists("temp.png"))
            {
                File.Delete("temp.png");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}