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
        // Hardcoded input image paths
        string[] inputPaths = {
            "input1.png",
            "input2.png",
            "input3.png"
        };

        // Hardcoded output APNG path
        string outputPath = "output/animated_output.png";

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the first image to obtain canvas size
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            // Apply Bradley thresholding to the first image (preserve for first frame)
            firstImage.BinarizeBradley(0.15, 15);

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                firstImage.Width,
                firstImage.Height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add the processed first frame
                apngImage.AddFrame(firstImage);

                // Process remaining images
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        // Apply Bradley thresholding
                        frame.BinarizeBradley(0.15, 15);

                        // Add the binarized frame to the animation
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the APNG file (output path already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}