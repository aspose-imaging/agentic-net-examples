using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define a manual clipping mask
        GraphicsPath manualMask = new GraphicsPath();
        Figure figure = new Figure();
        figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
        figure.AddShape(new RectangleShape(new RectangleF(200, 200, 150, 80)));
        manualMask.AddFigure(figure);

        // Prepare export options (PNG with transparency)
        PngOptions exportOptions = new PngOptions
        {
            ColorType = PngColorType.TruecolorWithAlpha,
            Source = new StreamSource(new MemoryStream())
        };

        // Set up manual masking arguments
        ManualMaskingArgs args = new ManualMaskingArgs
        {
            Mask = manualMask
        };

        // Load the source image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure masking options
            MaskingOptions maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.Manual,
                Decompose = false,
                Args = args,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Perform masking
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