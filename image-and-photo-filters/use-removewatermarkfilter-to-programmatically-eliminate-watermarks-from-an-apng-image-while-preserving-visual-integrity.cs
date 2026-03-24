using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source APNG image
        using (ApngImage sourceApng = (ApngImage)Image.Load(inputPath))
        {
            // Prepare options for the output APNG
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create a new APNG image for the result
            using (ApngImage resultApng = (ApngImage)Image.Create(createOptions, sourceApng.Width, sourceApng.Height))
            {
                resultApng.RemoveAllFrames();

                // Process each frame
                for (int i = 0; i < sourceApng.PageCount; i++)
                {
                    // Cast the current frame to RasterImage
                    using (RasterImage frame = (RasterImage)sourceApng.Pages[i])
                    {
                        // Define a mask (example ellipse)
                        var mask = new GraphicsPath();
                        var figure = new Figure();
                        figure.AddShape(new EllipseShape(new RectangleF(10, 10, 100, 50)));
                        mask.AddFigure(figure);

                        // Configure watermark removal options (Telea algorithm)
                        var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                        // Remove watermark from the frame
                        using (RasterImage cleaned = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(frame, options))
                        {
                            // Add the cleaned frame to the result APNG
                            resultApng.AddFrame(cleaned);
                        }
                    }
                }

                // Save the resulting APNG
                resultApng.Save();
            }
        }
    }
}