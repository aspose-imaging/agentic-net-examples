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
        string inputPath = args.Length > 0 ? args[0] : Path.Combine(Environment.CurrentDirectory, "input.cdr");
        string outputPath = args.Length > 1 ? args[1] : Path.Combine(Environment.CurrentDirectory, "output.psd");

        using (Image image = Image.Load(inputPath))
        {
            CdrImage cdrImage = image as CdrImage;
            if (cdrImage == null)
                throw new InvalidOperationException("The provided file is not a valid CDR image.");

            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Rgb,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageWidth = cdrImage.Width,
                    PageHeight = cdrImage.Height
                }
            };

            cdrImage.Save(outputPath, psdOptions);
        }
    }
}