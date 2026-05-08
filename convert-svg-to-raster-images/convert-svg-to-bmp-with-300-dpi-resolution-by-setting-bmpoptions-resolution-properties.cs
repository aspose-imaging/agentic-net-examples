using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.BackgroundColor = Color.White;
                rasterOptions.PageWidth = image.Width;
                rasterOptions.PageHeight = image.Height;

                bmpOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}