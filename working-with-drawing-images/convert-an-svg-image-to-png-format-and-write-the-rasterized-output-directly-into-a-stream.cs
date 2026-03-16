using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputSvgPath = "input.svg";

        using (MemoryStream outputStream = new MemoryStream())
        {
            using (Image image = Image.Load(inputSvgPath))
            {
                VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputStream, pngOptions);
            }

            using (FileStream file = new FileStream("output.png", FileMode.Create, FileAccess.Write))
            {
                outputStream.Position = 0;
                outputStream.CopyTo(file);
            }
        }
    }
}