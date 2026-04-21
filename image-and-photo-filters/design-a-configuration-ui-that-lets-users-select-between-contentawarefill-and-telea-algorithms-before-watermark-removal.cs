using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional as per requirements)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Simple console UI for algorithm selection
            Console.WriteLine("Select watermark removal algorithm:");
            Console.WriteLine("1 - Telea");
            Console.WriteLine("2 - Content Aware Fill");
            Console.Write("Enter choice (1 or 2): ");
            string choice = Console.ReadLine();

            // Load the image
            using (var image = Image.Load(inputPath))
            {
                // Cast to a specific format (PNG) for the remover
                var pngImage = (PngImage)image;

                // Create a mask (example ellipse)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 220, 230)));
                mask.AddFigure(figure);

                // Choose options based on user selection
                Aspose.Imaging.Watermark.Options.WatermarkOptions options;
                if (choice == "2")
                {
                    var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = 4
                    };
                    options = cafOptions;
                }
                else
                {
                    var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                    options = teleaOptions;
                }

                // Perform watermark removal
                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options);

                // Save the resulting image
                result.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}