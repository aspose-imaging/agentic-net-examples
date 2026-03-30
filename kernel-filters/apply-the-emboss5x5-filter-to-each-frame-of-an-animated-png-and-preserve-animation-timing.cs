using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)image;

            for (int i = 0; i < apng.PageCount; i++)
            {
                var frame = (Aspose.Imaging.RasterImage)apng.Pages[i];
                frame.Filter(frame.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));
            }

            apng.Save(outputPath, new ApngOptions());
        }
    }
}