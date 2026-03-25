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
        string inputPath1 = "frameA.png";
        string inputPath2 = "frameB.png";
        string inputPath3 = "frameC.png";

        // Hardcoded output APNG file path
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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load each PNG as a RasterImage
        using (RasterImage frame1 = (RasterImage)Image.Load(inputPath1))
        using (RasterImage frame2 = (RasterImage)Image.Load(inputPath2))
        using (RasterImage frame3 = (RasterImage)Image.Load(inputPath3))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image using the size of the first frame
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, frame1.Width, frame1.Height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                // Add each loaded frame to the animation
                apngImage.AddFrame(frame1);
                apngImage.AddFrame(frame2);
                apngImage.AddFrame(frame3);

                // Save the APNG (output is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}