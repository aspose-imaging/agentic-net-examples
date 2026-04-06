using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Input JPG files (hardcoded)
        string inputPath1 = "frame1.jpg";
        string inputPath2 = "frame2.jpg";
        string inputPath3 = "frame3.jpg";

        // Output APNG file (hardcoded)
        string outputPath = "animation_output.png";

        // Validate input files
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
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load first image to obtain canvas size
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPath1))
        {
            int canvasWidth = firstImage.Width;
            int canvasHeight = firstImage.Height;

            // Create APNG options with bound output file
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 100 // 100 ms per frame
            };

            // Create APNG canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, canvasWidth, canvasHeight))
            {
                // Remove default frame
                apngImage.RemoveAllFrames();

                // Add first frame
                apngImage.AddFrame(firstImage);

                // Add second frame
                using (RasterImage secondImage = (RasterImage)Image.Load(inputPath2))
                {
                    apngImage.AddFrame(secondImage);
                }

                // Add third frame
                using (RasterImage thirdImage = (RasterImage)Image.Load(inputPath3))
                {
                    apngImage.AddFrame(thirdImage);
                }

                // Save the APNG (output path already bound)
                apngImage.Save();
            }
        }
    }
}