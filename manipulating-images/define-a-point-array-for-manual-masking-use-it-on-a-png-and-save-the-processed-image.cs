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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define a Point array for manual masking (used in a polygon shape)
        Point[] maskPoints = new Point[]
        {
            new Point(30, 30),
            new Point(70, 30),
            new Point(70, 70),
            new Point(30, 70)
        };

        // Build the manual mask using GraphicsPath
        GraphicsPath manualMask = new GraphicsPath();
        Figure figure = new Figure();
        // Example shapes: a polygon defined by points and an ellipse
        figure.AddShape(new PolygonShape(maskPoints));
        figure.AddShape(new EllipseShape(new RectangleF(100, 100, 80, 80)));
        manualMask.AddFigure(figure);

        // Export options for PNG with transparent background
        PngOptions exportOptions = new PngOptions
        {
            ColorType = PngColorType.TruecolorWithAlpha,
            Source = new StreamSource(new MemoryStream())
        };

        // Set up manual masking arguments
        ManualMaskingArgs argsMask = new ManualMaskingArgs
        {
            Mask = manualMask
        };

        // Load the source image as RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure masking options
            MaskingOptions maskingOptions = new MaskingOptions
            {
                Method = Masking.Options.SegmentationMethod.Manual,
                Decompose = false,
                Args = argsMask,
                BackgroundReplacementColor = Color.Orange,
                ExportOptions = exportOptions,
                // Optional: limit masking to a specific area (full image here)
                MaskingArea = new Rectangle(0, 0, image.Width, image.Height)
            };

            // Perform manual masking
            ImageMasking masking = new ImageMasking(image);
            using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
            {
                // Save the foreground segment (index 1) as the processed image
                using (Image resultImage = maskingResult[1].GetImage())
                {
                    resultImage.Save(outputPath, exportOptions);
                }
            }
        }
    }
}