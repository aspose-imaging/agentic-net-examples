// HOW-TO: Apply Manual Polygon Mask to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            PointF[] maskPoints = new PointF[]
            {
                new PointF(50, 50),
                new PointF(150, 50),
                new PointF(150, 150),
                new PointF(50, 150)
            };

            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new PolygonShape(maskPoints));
            manualMask.AddFigure(figure);

            ManualMaskingArgs argsMask = new ManualMaskingArgs
            {
                Mask = manualMask
            };

            PngOptions exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.Manual,
                    Decompose = false,
                    Args = argsMask,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    using (RasterImage resultImage = (RasterImage)maskingResult[1].GetImage())
                    {
                        resultImage.Save(outputPath, exportOptions);
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

/*
 * Real-World Use Cases:
 * 1. When you need to hide or remove a specific rectangular area of a PNG by defining custom polygon coordinates in C#.
 * 2. When you want to replace the background of a PNG with transparency after manually selecting the region to keep.
 * 3. When you are building a batch tool that programmatically masks logos or watermarks on images using a predefined set of points.
 * 4. When you need to export a masked PNG with truecolor with alpha channel while preserving image quality in a .NET application.
 * 5. When you are integrating Aspose.Imaging to create custom-shaped cutouts for UI assets or game sprites based on manual point arrays.
 */
