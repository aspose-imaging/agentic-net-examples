using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source image as RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Define a manual mask using graphics path and shapes
            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
            figure.AddShape(new RectangleShape(new RectangleF(200, 200, 150, 150)));
            manualMask.AddFigure(figure);

            // Prepare manual masking arguments
            ManualMaskingArgs maskArgs = new ManualMaskingArgs
            {
                Mask = manualMask
            };

            // Export options for the masking operation (in‑memory PNG)
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
                Args = maskArgs,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            // Perform masking
            using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
            {
                // Retrieve the foreground image (masked object)
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save the result as APNG preserving transparency
                    foreground.Save(outputPath, new ApngOptions
                    {
                        DefaultFrameTime = 200, // milliseconds per frame
                        NumPlays = 0             // infinite loop
                    });
                }
            }
        }
    }
}