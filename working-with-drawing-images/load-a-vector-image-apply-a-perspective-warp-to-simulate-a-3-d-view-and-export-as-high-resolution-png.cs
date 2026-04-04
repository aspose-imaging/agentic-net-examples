using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            // High-resolution PNG options
            var pngOptions = new PngOptions
            {
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            // SVG rasterization options
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Simulate perspective warp by non-uniform scaling
            int newWidth = image.Width * 2;
            int newHeight = image.Height;
            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Save the result
            image.Save(outputPath, pngOptions);
        }
    }
}