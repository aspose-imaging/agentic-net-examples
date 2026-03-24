using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputDirectory = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the source image (could be multi-page/animated)
        using (Image image = Image.Load(inputPath))
        {
            // Check if the image supports multiple pages/frames
            if (image is IMultipageImage multipage)
            {
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Extract the current frame as a RasterImage
                    using (RasterImage frame = (RasterImage)multipage.Pages[i])
                    {
                        // Build output file path for this frame
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.png");

                        // Prepare APNG creation options with bound output source
                        ApngOptions options = new ApngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };

                        // Create a new APNG image, add the single frame, and save
                        using (ApngImage apng = (ApngImage)Image.Create(options, frame.Width, frame.Height))
                        {
                            apng.RemoveAllFrames(); // Ensure no default frame exists
                            apng.AddFrame(frame);
                            apng.Save(); // Output is already bound via FileCreateSource
                        }
                    }
                }
            }
            else
            {
                // Single-frame image: treat it as one frame
                using (RasterImage frame = (RasterImage)image)
                {
                    string outputPath = Path.Combine(outputDirectory, "frame_0.png");
                    ApngOptions options = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    using (ApngImage apng = (ApngImage)Image.Create(options, frame.Width, frame.Height))
                    {
                        apng.RemoveAllFrames();
                        apng.AddFrame(frame);
                        apng.Save();
                    }
                }
            }
        }
    }
}