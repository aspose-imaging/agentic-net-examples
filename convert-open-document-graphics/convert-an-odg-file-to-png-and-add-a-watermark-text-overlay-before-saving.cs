using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string tempPath = Path.Combine(Path.GetTempPath(), "temp_converted.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            using (Image odgImage = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
                odgImage.Save(tempPath, pngOptions);
            }

            using (Image pngImage = Image.Load(tempPath))
            {
                Graphics graphics = new Graphics(pngImage);
                Font font = new Font("Arial", 24);
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    graphics.DrawString("Watermark", font, brush, new PointF(10, 10));
                }
                pngImage.Save(outputPath);
            }

            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}