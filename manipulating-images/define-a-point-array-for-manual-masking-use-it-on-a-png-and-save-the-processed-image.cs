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
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a manual mask using graphics shapes
            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 40, 40)));
            figure.AddShape(new RectangleShape(new RectangleF(10, 20, 50, 30)));
            manualMask.AddFigure(figure);

            // Set manual masking arguments
            ManualMaskingArgs maskArgs = new ManualMaskingArgs
            {
                Mask = manualMask
            };

            // Export options for PNG output
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
                BackgroundReplacementColor = Color.Orange,
                ExportOptions = exportOptions
            };

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Perform manual masking
                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Save the foreground segment (index 1) to the output file
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