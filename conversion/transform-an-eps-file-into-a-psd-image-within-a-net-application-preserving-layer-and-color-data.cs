using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.psd";

        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            using (PsdOptions psdOptions = new PsdOptions())
            {
                psdOptions.CompressionMethod = CompressionMethod.RLE;
                psdOptions.ColorMode = ColorModes.Rgb;

                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                };
                psdOptions.VectorRasterizationOptions = vectorOptions;

                psdOptions.VectorizationOptions = new PsdVectorizationOptions
                {
                    VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                };

                epsImage.Save(outputPath, psdOptions);
            }
        }
    }
}