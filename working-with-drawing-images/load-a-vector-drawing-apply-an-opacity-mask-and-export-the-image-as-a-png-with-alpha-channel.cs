using System;
using System.IO;
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
        // Hardcoded input and output paths
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

        // Load the vector drawing (Aspose.Imaging will rasterize it internally)
        using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Define a simple rectangular opacity mask
            Aspose.Imaging.GraphicsPath maskPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
            // Mask covers the left half of the image
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(0, 0, raster.Width / 2f, raster.Height)));
            maskPath.AddFigure(figure);

            // Configure masking options
            var maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.Manual,
                Decompose = false,
                Args = new ManualMaskingArgs { Mask = maskPath },
                BackgroundReplacementColor = Aspose.Imaging.Color.Transparent,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                }
            };

            // Apply the mask and obtain the resulting image
            using (MaskingResult result = new ImageMasking(raster).Decompose(maskingOptions))
            using (Aspose.Imaging.Image maskedImage = result[1].GetImage())
            {
                // Save the masked image as PNG with alpha channel
                maskedImage.Save(outputPath, (PngOptions)maskingOptions.ExportOptions);
            }
        }
    }
}