using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics;
                try
                {
                    graphics = new Graphics(image);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Failed to create Graphics: {ex.Message}");
                    return;
                }

                graphics.Clear(Color.White);
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, new Rectangle(10, 10, 100, 100));
                }

                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}