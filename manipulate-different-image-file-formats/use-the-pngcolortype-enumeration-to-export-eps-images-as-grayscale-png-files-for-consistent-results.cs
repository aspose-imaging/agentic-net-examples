using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputPath = Path.Combine("Input", "sample.eps");
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = Path.Combine("Output", "sample_grayscale.png");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image and export as grayscale PNG
        using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
        {
            var options = new PngOptions
            {
                ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.Grayscale,
                VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                }
            };

            image.Save(outputPath, options);
        }
    }
}