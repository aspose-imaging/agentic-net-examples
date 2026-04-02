using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputJpegPath = "input.jpg";
        string inputPngPath = "input.png";
        string outputPath = "output.png";

        // Validate input files
        if (!File.Exists(inputJpegPath))
        {
            Console.Error.WriteLine($"File not found: {inputJpegPath}");
            return;
        }
        if (!File.Exists(inputPngPath))
        {
            Console.Error.WriteLine($"File not found: {inputPngPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source images
        using (RasterImage jpegImage = (RasterImage)Image.Load(inputJpegPath))
        using (RasterImage pngImage = (RasterImage)Image.Load(inputPngPath))
        {
            // Calculate canvas size for horizontal merge
            int canvasWidth = jpegImage.Width + pngImage.Width;
            int canvasHeight = Math.Max(jpegImage.Height, pngImage.Height);

            // Prepare PNG options with bound output source
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = outputSource };

            // Create canvas
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Copy JPEG image onto canvas at (0,0)
                Rectangle jpegBounds = new Rectangle(0, 0, jpegImage.Width, jpegImage.Height);
                canvas.SaveArgb32Pixels(jpegBounds, jpegImage.LoadArgb32Pixels(jpegImage.Bounds));

                // Copy PNG image onto canvas next to JPEG
                int offsetX = jpegImage.Width;
                Rectangle pngBounds = new Rectangle(offsetX, 0, pngImage.Width, pngImage.Height);
                canvas.SaveArgb32Pixels(pngBounds, pngImage.LoadArgb32Pixels(pngImage.Bounds));

                // Save the bound canvas
                canvas.Save();
            }
        }
    }
}