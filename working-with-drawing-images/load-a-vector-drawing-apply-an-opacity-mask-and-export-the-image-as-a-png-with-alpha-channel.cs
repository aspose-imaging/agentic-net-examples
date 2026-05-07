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
            // Hard‑coded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector drawing (will be rasterized automatically)
            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                // Define a simple rectangular opacity mask
                GraphicsPath manualMask = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 200)));
                manualMask.AddFigure(figure);

                // PNG export options with alpha channel
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking to use the manual mask and make background transparent
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.Manual,
                    Decompose = false,
                    Args = new ManualMaskingArgs { Mask = manualMask },
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Apply the mask and obtain the masked image
                ImageMasking masking = new ImageMasking(source);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                {
                    using (RasterImage masked = (RasterImage)result[1].GetImage())
                    {
                        // Save the final PNG with alpha channel
                        masked.Save(outputPath, exportOptions);
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