using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.png";

            // Ensure directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a simple test PNG: red background with a blue pixel at (1,1)
            var createOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(inputPath, false)
            };
            using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Create(createOptions, 2, 2))
            {
                var png = (PngImage)img;
                // Fill all pixels with red
                png.SavePixels(new Aspose.Imaging.Rectangle(0, 0, 2, 2), new Aspose.Imaging.Color[]
                {
                    Aspose.Imaging.Color.Red, Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Red, Aspose.Imaging.Color.Red
                });
                // Draw a blue pixel at (1,1)
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(png);
                graphics.FillRectangle(new SolidBrush(Aspose.Imaging.Color.Blue), new Aspose.Imaging.Rectangle(1, 1, 1, 1));
                png.Save();
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare export options for masking result
            var exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Define a manual mask covering the blue pixel (foreground)
            var manualMask = new Aspose.Imaging.GraphicsPath();
            var figure = new Aspose.Imaging.Figure();
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(1, 1, 1, 1)));
            manualMask.AddFigure(figure);

            // Configure masking options to make background transparent
            var maskingOptions = new MaskingOptions
            {
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.Manual,
                Decompose = false,
                Args = new ManualMaskingArgs { Mask = manualMask },
                BackgroundReplacementColor = Aspose.Imaging.Color.Transparent,
                ExportOptions = exportOptions
            };

            // Perform masking
            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
            using (Aspose.Imaging.RasterImage resultImage = (Aspose.Imaging.RasterImage)maskingResult[1].GetImage())
            {
                resultImage.Save(outputPath, exportOptions);
            }

            // Load the result and verify transparency
            using (Aspose.Imaging.RasterImage finalImg = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(outputPath))
            {
                // Background pixel at (0,0) should be fully transparent (alpha = 0)
                int[] bgPixel = finalImg.LoadArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, 1, 1));
                int bgAlpha = (bgPixel[0] >> 24) & 0xFF;

                // Foreground pixel at (1,1) should be opaque (alpha = 255)
                int[] fgPixel = finalImg.LoadArgb32Pixels(new Aspose.Imaging.Rectangle(1, 1, 1, 1));
                int fgAlpha = (fgPixel[0] >> 24) & 0xFF;

                if (bgAlpha == 0 && fgAlpha == 255)
                {
                    Console.WriteLine("Test passed: background is transparent and foreground is opaque.");
                }
                else
                {
                    Console.WriteLine("Test failed: unexpected alpha values.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}