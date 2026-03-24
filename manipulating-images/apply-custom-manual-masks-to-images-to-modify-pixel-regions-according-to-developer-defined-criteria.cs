using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        GraphicsPath manualMask = new GraphicsPath();
        Figure figure = new Figure();
        figure.AddShape(new EllipseShape(new RectangleF(50, 50, 40, 40)));
        figure.AddShape(new RectangleShape(new RectangleF(10, 20, 50, 30)));
        manualMask.AddFigure(figure);

        PngOptions exportOptions = new PngOptions
        {
            ColorType = PngColorType.TruecolorWithAlpha,
            Source = new StreamSource(new MemoryStream())
        };

        ManualMaskingArgs maskingArgs = new ManualMaskingArgs
        {
            Mask = manualMask
        };

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            MaskingOptions maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.Manual,
                Decompose = false,
                Args = maskingArgs,
                BackgroundReplacementColor = Color.Orange,
                ExportOptions = exportOptions
            };

            ImageMasking masking = new ImageMasking(image);

            using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
            {
                using (Image foreground = maskingResult[1].GetImage())
                {
                    foreground.Save(outputPath, exportOptions);
                }
            }
        }
    }
}