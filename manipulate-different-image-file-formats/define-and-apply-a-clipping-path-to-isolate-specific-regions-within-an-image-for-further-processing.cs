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
        string outputPath = "clipped.png";

        // Load the source image as RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Define a manual clipping mask (e.g., an ellipse)
            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            // Adjust the rectangle to define the region to keep
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 300, 300)));
            manualMask.AddFigure(figure);

            // Prepare manual masking arguments
            ManualMaskingArgs maskingArgs = new ManualMaskingArgs();
            maskingArgs.Mask = manualMask;

            // Prepare export options (required for masking)
            using (MemoryStream ms = new MemoryStream())
            {
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(ms)
                };

                // Configure masking options
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.Manual,
                    Decompose = false,               // Keep mask as a single foreground object
                    Args = maskingArgs,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Perform manual masking
                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // The foreground (clipped region) is at index 1
                    using (RasterImage clipped = (RasterImage)maskingResult[1].GetImage())
                    {
                        // Save the clipped image
                        clipped.Save(outputPath, exportOptions);
                    }
                }
            }
        }
    }
}