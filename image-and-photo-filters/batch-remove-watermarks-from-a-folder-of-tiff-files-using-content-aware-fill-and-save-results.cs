using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input_tiffs";
            string outputFolder = "output_tiffs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            foreach (var inputPath in Directory.GetFiles(inputFolder, "*.tif"))
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + "_cleaned.tif");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
                {
                    // Create a mask covering the whole image
                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(0, 0, tiffImage.Width, tiffImage.Height)));
                    mask.AddFigure(figure);

                    var options = new ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = 4
                    };

                    using (RasterImage result = WatermarkRemover.PaintOver(tiffImage, options))
                    {
                        var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                        result.Save(outputPath, saveOptions);
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