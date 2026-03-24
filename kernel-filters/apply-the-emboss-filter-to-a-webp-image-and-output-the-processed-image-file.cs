using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        string inputPath = "input.webp";
        string outputPath = "output_emboss.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.FileFormats.Webp.WebPImage webpImage = (Aspose.Imaging.FileFormats.Webp.WebPImage)image;

            var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

            webpImage.Filter(webpImage.Bounds, embossOptions);

            var saveOptions = new WebPOptions();
            webpImage.Save(outputPath, saveOptions);
        }
    }
}