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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/result.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Enhance text clarity: adjust brightness and contrast
            sourceImage.AdjustBrightness(30);          // increase brightness
            sourceImage.AdjustContrast(20f);           // increase contrast

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG canvas and add the processed frame
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                apngImage.RemoveAllFrames();          // clear default frame
                apngImage.AddFrame(sourceImage);       // add the enhanced image as the sole frame
                apngImage.Save();                      // save to the bound output file
            }
        }
    }
}