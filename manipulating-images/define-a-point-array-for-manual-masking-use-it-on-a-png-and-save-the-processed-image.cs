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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Point[] maskPoints = new Point[]
            {
                new Point(30, 30),
                new Point(70, 30),
                new Point(70, 70),
                new Point(30, 70)
            };

            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            RectangleF rect = new RectangleF(
                maskPoints[0].X,
                maskPoints[0].Y,
                maskPoints[1].X - maskPoints[0].X,
                maskPoints[2].Y - maskPoints[0].Y);
            figure.AddShape(new RectangleShape(rect));
            manualMask.AddFigure(figure);

            ManualMaskingArgs argsMask = new ManualMaskingArgs();
            argsMask.Mask = manualMask;

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
                    BackgroundReplacementColor = Color.Orange,
                    ExportOptions = exportOptions
                };

                using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
                {
                    using (RasterImage foreground = (RasterImage)results[1].GetImage())
                    {
                        foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When a developer needs to hide sensitive information in a PNG by defining a rectangular region with specific coordinates and applying a manual mask before saving the image.
 * 2. When an application must programmatically remove a logo or watermark from a PNG by creating a Point array that outlines the area to be masked using Aspose.Imaging’s ManualMaskingArgs.
 * 3. When a batch‑processing tool has to replace the background of selected PNG files with transparency by constructing a GraphicsPath from points and exporting the result with PngOptions.
 * 4. When a C# service integrates Aspose.Imaging to isolate a region of interest in a PNG for further analysis, using a manual segmentation method and saving the masked output.
 * 5. When a desktop utility needs to generate a cropped PNG preview by defining corner points, applying a manual mask, and writing the processed image to disk with true‑color with alpha support.
 */