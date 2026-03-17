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
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the source image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Define a manual clipping path (mask)
            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            // Example shapes: an ellipse and a rectangle
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 150)));
            figure.AddShape(new RectangleShape(new RectangleF(100, 200, 120, 80)));
            manualMask.AddFigure(figure);

            // Set up manual masking arguments
            ManualMaskingArgs maskingArgs = new ManualMaskingArgs();
            maskingArgs.Mask = manualMask;

            // Export options for the resulting image (transparent PNG)
            PngOptions exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure masking options
            MaskingOptions maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.Manual,
                Decompose = false,
                Args = maskingArgs,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Perform masking
            ImageMasking masking = new ImageMasking(image);
            using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
            {
                // The foreground (masked region) is typically at index 1
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save the isolated region
                    foreground.Save(outputPath, exportOptions);
                }
            }
        }
    }
}