using System;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.cmx";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        using (Aspose.Imaging.Image cmxImage = Aspose.Imaging.Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = cmxImage.Width,
                PageHeight = cmxImage.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            cmxImage.Save(outputPath, pngOptions);
        }
    }
}