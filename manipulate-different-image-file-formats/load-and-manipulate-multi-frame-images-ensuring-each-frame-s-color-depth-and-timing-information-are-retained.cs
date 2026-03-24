using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source multi-frame APNG image
        using (ApngImage sourceImage = (ApngImage)Image.Load(inputPath))
        {
            // Preserve default frame time and dimensions
            uint defaultFrameTime = sourceImage.DefaultFrameTime;

            // Create options for the new APNG image, binding it to the output file
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = defaultFrameTime,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create a new APNG image with the same size as the source
            using (ApngImage resultImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the automatically added first frame
                resultImage.RemoveAllFrames();

                // Copy each frame from the source, preserving its timing information
                foreach (ApngFrame srcFrame in sourceImage.Pages)
                {
                    // Add the frame content
                    resultImage.AddFrame((RasterImage)srcFrame);

                    // Retrieve the newly added frame to set its specific frame time
                    ApngFrame addedFrame = (ApngFrame)resultImage.Pages[resultImage.PageCount - 1];
                    addedFrame.FrameTime = srcFrame.FrameTime;
                }

                // Save the result; the output path is already bound via FileCreateSource
                resultImage.Save();
            }
        }
    }
}