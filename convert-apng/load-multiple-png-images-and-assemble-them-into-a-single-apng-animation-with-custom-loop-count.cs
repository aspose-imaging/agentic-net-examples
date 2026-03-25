using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = "frame1.png";
        string inputPath2 = "frame2.png";
        string inputPath3 = "frame3.png";
        string outputPath = "animation.apng";

        // Verify each input file exists
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }
        if (!File.Exists(inputPath3))
        {
            Console.Error.WriteLine($"File not found: {inputPath3}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the first image to obtain canvas size
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPath1))
        {
            int width = firstImage.Width;
            int height = firstImage.Height;

            // Create APNG options with custom loop count and frame duration
            Source fileSource = new FileCreateSource(outputPath, false);
            ApngOptions options = new ApngOptions
            {
                Source = fileSource,
                DefaultFrameTime = 100, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha,
                NumPlays = 3 // custom loop count
            };

            // Create the APNG canvas (output is already bound to the file source)
            using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
            {
                // Remove the default frame that exists upon creation
                apng.RemoveAllFrames();

                // Add the first frame (already loaded)
                apng.AddFrame(firstImage);

                // Load and add the second frame
                using (RasterImage second = (RasterImage)Image.Load(inputPath2))
                {
                    apng.AddFrame(second);
                }

                // Load and add the third frame
                using (RasterImage third = (RasterImage)Image.Load(inputPath3))
                {
                    apng.AddFrame(third);
                }

                // Save the assembled APNG animation
                apng.Save();
            }
        }
    }
}