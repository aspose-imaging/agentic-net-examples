using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                if (image is VectorImage)
                {
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                }

                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}