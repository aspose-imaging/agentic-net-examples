using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pdf";
        string outputPath = "output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            SvgOptions exportOptions = new SvgOptions();

            exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, 2));

            if (image is VectorImage)
            {
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };
                exportOptions.VectorRasterizationOptions = rasterOptions;
            }

            image.Save(outputPath, exportOptions);
        }
    }
}