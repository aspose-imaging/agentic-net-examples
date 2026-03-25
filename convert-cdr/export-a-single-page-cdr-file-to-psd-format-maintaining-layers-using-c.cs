using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.cdr");
        string outputPath = Path.Combine("Output", "sample.psd");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Rgb,
                VectorizationOptions = new PsdVectorizationOptions
                {
                    VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                }
            };

            VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = cdr.Width,
                PageHeight = cdr.Height,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            psdOptions.VectorRasterizationOptions = vectorOptions;

            cdr.Save(outputPath, psdOptions);
        }
    }
}