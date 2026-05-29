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
            // Hardcoded input directory and output file
            string inputDir = "input_images";
            string outputPath = "output/animation.apng";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Hardcoded frame file paths (alphabetical order)
            string[] framePaths = new string[]
            {
                Path.Combine(inputDir, "frame1.png"),
                Path.Combine(inputDir, "frame2.png"),
                Path.Combine(inputDir, "frame3.png")
            };

            // Verify each input file exists
            foreach (string path in framePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Load first frame to obtain dimensions
            int width, height;
            using (RasterImage first = (RasterImage)Image.Load(framePaths[0]))
            {
                width = first.Width;
                height = first.Height;
            }

            // Create APNG options with output source
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default frame duration in ms
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                // Add each frame to the animation
                foreach (string path in framePaths)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(path))
                    {
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the APNG (output path already bound)
                apngImage.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}