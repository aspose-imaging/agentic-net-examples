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
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image as a raster image
        using (RasterImage jpegImage = (RasterImage)Image.Load(inputPath))
        {
            // Prepare PNG options with a bound file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a PNG canvas with the same dimensions as the JPEG
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, jpegImage.Width, jpegImage.Height))
            {
                // Blend the JPEG onto the canvas with 127 (≈50%) opacity
                canvas.Blend(new Point(0, 0), jpegImage, 127);

                // Save the bound canvas (outputPath is already set in the source)
                canvas.Save();
            }
        }
    }
}