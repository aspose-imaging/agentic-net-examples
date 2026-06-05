using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "Input", "sample.svg");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "sample.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}