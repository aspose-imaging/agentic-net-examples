using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

        foreach (string inputPath in pngFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (SvgOptions svgOptions = new SvgOptions())
            {
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions();
                vectorOptions.BackgroundColor = Aspose.Imaging.Color.White;
                vectorOptions.PageWidth = image.Width;
                vectorOptions.PageHeight = image.Height;

                svgOptions.VectorRasterizationOptions = vectorOptions;

                image.Save(outputPath, svgOptions);
            }
        }
    }
}