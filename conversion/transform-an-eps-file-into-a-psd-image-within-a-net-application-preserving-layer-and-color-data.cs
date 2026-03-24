using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.psd";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            var psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Rgb
            };

            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };
            psdOptions.VectorRasterizationOptions = vectorOptions;

            var vectorizationOptions = new PsdVectorizationOptions
            {
                VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
            };
            psdOptions.VectorizationOptions = vectorizationOptions;

            epsImage.Save(outputPath, psdOptions);
        }
    }
}