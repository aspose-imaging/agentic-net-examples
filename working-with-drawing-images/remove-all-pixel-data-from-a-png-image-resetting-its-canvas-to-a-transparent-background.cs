using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source PNG image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            // Prepare PNG options with a bound file source
            Source fileSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions
            {
                Source = fileSource,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create a new PNG canvas bound to the output file
            using (PngImage canvas = (PngImage)Image.Create(pngOptions, width, height))
            {
                // Clear the canvas to a fully transparent background
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.Transparent);

                // Save the canvas (output path already bound)
                canvas.Save();
            }
        }
    }
}