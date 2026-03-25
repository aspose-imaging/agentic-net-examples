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
        string outputPath = "output.apng";

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
            // Create APNG options with 100 ms default frame time
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100u,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Remove the default initial frame
                apngImage.RemoveAllFrames();

                // Add multiple frames (duplicate the same source image)
                const int frameCount = 10;
                for (int i = 0; i < frameCount; i++)
                {
                    apngImage.AddFrame(sourceImage);
                }

                // Save the APNG (output path already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}