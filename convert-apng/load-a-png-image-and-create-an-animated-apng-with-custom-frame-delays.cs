using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\animation.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // default frame time in ms
                    ColorType = PngColorType.TruecolorWithAlpha,
                    NumPlays = 0 // infinite looping
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    apngImage.RemoveAllFrames();

                    // Add frames with custom delays
                    apngImage.AddFrame(sourceImage, 100); // 100 ms
                    apngImage.AddFrame(sourceImage, 200); // 200 ms
                    apngImage.AddFrame(sourceImage, 300); // 300 ms
                    apngImage.AddFrame(sourceImage, 200); // 200 ms
                    apngImage.AddFrame(sourceImage, 100); // 100 ms

                    apngImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}