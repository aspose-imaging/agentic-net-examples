using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Prepare a reusable ellipse mask
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Example ellipse; adjust as needed
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);
            var options = new TeleaWatermarkOptions(mask);

            // Process each PNG file in the input folder
            foreach (string filePath in Directory.GetFiles(inputFolder, "*.png"))
            {
                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string fileName = Path.GetFileName(filePath);
                string outputPath = Path.Combine(outputFolder, fileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(filePath))
                {
                    // Cast to PngImage as required by WatermarkRemover
                    var pngImage = (PngImage)image;

                    // Apply Telea watermark removal with the predefined mask
                    var result = WatermarkRemover.PaintOver(pngImage, options);

                    // Save the processed image
                    result.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}