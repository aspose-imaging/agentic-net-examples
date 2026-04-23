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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output\\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a PointF array for the manual mask
            PointF[] maskPoints = new PointF[]
            {
                new PointF(30, 30),
                new PointF(80, 30),
                new PointF(80, 80),
                new PointF(30, 80)
            };

            // Build the manual mask using the point array
            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new PolygonShape(maskPoints));
            manualMask.AddFigure(figure);

            // Export options for PNG with transparency
            PngOptions exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Set up manual masking arguments
            ManualMaskingArgs manualMaskingArgs = new ManualMaskingArgs
            {
                Mask = manualMask
            };

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Configure masking options
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.Manual,
                    Decompose = false,
                    Args = manualMaskingArgs,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Perform masking
                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Save the foreground segment (index 1) to the output file
                    using (Image resultImage = maskingResult[1].GetImage())
                    {
                        resultImage.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}