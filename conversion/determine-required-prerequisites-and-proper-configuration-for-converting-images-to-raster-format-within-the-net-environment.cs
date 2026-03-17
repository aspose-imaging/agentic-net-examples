using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            vectorImage.Save(outputPath, pngOptions);
        }
    }
}