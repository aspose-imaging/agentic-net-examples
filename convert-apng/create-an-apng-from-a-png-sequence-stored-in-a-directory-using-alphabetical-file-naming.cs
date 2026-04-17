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
        // Hardcoded input PNG file paths (alphabetical order)
        string inputPath1 = "frame1.png";
        string inputPath2 = "frame2.png";
        string inputPath3 = "frame3.png";

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

        // Hardcoded output APNG path (ensure it includes a directory)
        string outputPath = "output\\animation.apng";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the first image to obtain canvas dimensions
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPath1))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, firstImage.Width, firstImage.Height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                // Add each frame to the animation
                using (RasterImage frame1 = (RasterImage)Image.Load(inputPath1))
                {
                    apngImage.AddFrame(frame1);
                }
                using (RasterImage frame2 = (RasterImage)Image.Load(inputPath2))
                {
                    apngImage.AddFrame(frame2);
                }
                using (RasterImage frame3 = (RasterImage)Image.Load(inputPath3))
                {
                    apngImage.AddFrame(frame3);
                }

                // Save the APNG (output path already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}