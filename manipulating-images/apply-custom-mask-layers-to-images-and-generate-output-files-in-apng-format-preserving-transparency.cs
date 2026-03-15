using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input image and output APNG
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Create a manual mask using geometric shapes
        GraphicsPath manualMask = new GraphicsPath();
        Figure figure = new Figure();
        figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
        figure.AddShape(new RectangleShape(new RectangleF(100, 100, 150, 150)));
        manualMask.AddFigure(figure);

        // Configure masking options with the manual mask
        ManualMaskingArgs maskArgs = new ManualMaskingArgs { Mask = manualMask };
        MaskingOptions maskingOptions = new MaskingOptions
        {
            Method = Masking.Options.SegmentationMethod.Manual,
            Decompose = false,
            Args = maskArgs,
            BackgroundReplacementColor = Color.Transparent,
            ExportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            }
        };

        // Load the source image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Perform masking
            ImageMasking masking = new ImageMasking(sourceImage);
            using (MaskingResult result = masking.Decompose(maskingOptions))
            using (RasterImage foreground = (RasterImage)result[1].GetImage())
            {
                // Save the masked foreground as an APNG preserving transparency
                ApngOptions apngOptions = new ApngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };
                foreground.Save(outputPath, apngOptions);
            }
        }
    }
}