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
        string inputPath = @"input.svg";
        string outputPath = @"output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector drawing as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Create a manual mask covering the whole image
            GraphicsPath maskPath = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height)));
            maskPath.AddFigure(figure);

            // Prepare manual masking arguments
            ManualMaskingArgs manualArgs = new ManualMaskingArgs
            {
                Mask = maskPath
            };

            // Configure PNG export options with alpha channel
            PngOptions pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Set up masking options
            MaskingOptions maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.Manual,
                Decompose = false,
                Args = manualArgs,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = pngOptions
            };

            // Perform masking
            ImageMasking masking = new ImageMasking(sourceImage);
            using (MaskingResult result = masking.Decompose(maskingOptions))
            using (RasterImage maskedImage = (RasterImage)result[1].GetImage())
            {
                // Save the masked image as PNG with alpha channel
                maskedImage.Save(outputPath, pngOptions);
            }
        }
    }
}