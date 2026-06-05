using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Export options for the masking process
                using (PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                })
                {
                    // Auto‑masking options with user‑defined strokes
                    AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                    {
                        CalculateDefaultStrokes = false,
                        FeatheringRadius = 3,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = exportOptions,
                        BackgroundReplacementColor = Color.Transparent,
                        Args = new AutoMaskingArgs
                        {
                            ObjectsPoints = new Point[][]
                            {
                                // Background strokes
                                new Point[] { new Point(50, 50), new Point(60, 50) },
                                // Foreground strokes
                                new Point[] { new Point(100, 100), new Point(110, 110) }
                            }
                        }
                    };

                    using (MaskingResult maskingResult = new ImageMasking(image).Decompose(options))
                    {
                        using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                        {
                            // Align DPI (make horizontal and vertical resolution equal)
                            double dpi = Math.Max(foreground.HorizontalResolution, foreground.VerticalResolution);
                            foreground.HorizontalResolution = dpi;
                            foreground.VerticalResolution = dpi;

                            // Save the masked image as PNG
                            using (PngOptions saveOptions = new PngOptions
                            {
                                ColorType = PngColorType.TruecolorWithAlpha
                            })
                            {
                                foreground.Save(outputPath, saveOptions);
                            }
                        }
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