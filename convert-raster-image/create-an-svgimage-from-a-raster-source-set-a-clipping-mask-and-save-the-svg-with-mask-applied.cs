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
    static void Main()
    {
        string inputPath = "input.jpg";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Define a manual clipping mask (ellipse)
            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
            manualMask.AddFigure(figure);

            // Temporary export options for masking
            PngOptions exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure masking to apply the manual mask
            MaskingOptions maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.Manual,
                Decompose = false,
                Args = new ManualMaskingArgs { Mask = manualMask },
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions
            };

            ImageMasking masking = new ImageMasking(raster);
            using (MaskingResult result = masking.Decompose(maskingOptions))
            {
                using (RasterImage masked = (RasterImage)result[1].GetImage())
                {
                    // Save the masked raster image as SVG
                    SvgOptions svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = masked.Size
                        }
                    };
                    masked.Save(outputPath, svgOptions);
                }
            }
        }
    }
}