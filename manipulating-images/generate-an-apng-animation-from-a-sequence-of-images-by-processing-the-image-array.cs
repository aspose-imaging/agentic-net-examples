using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect at least one output path and one input image
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <outputPath> <inputImage1> [<inputImage2> ...]");
            return;
        }

        string outputPath = args[0];
        string[] inputPaths = args.Skip(1).ToArray();

        // Load the first image to obtain canvas size
        using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default frame duration in ms
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image with the determined dimensions
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, first.Width, first.Height))
            {
                // Ensure the image starts with no frames
                apngImage.RemoveAllFrames();

                // Add each input image as a frame
                foreach (string path in inputPaths)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(path))
                    {
                        // Resize frame if its dimensions differ from the canvas
                        if (frame.Width != first.Width || frame.Height != first.Height)
                        {
                            frame.Resize(first.Width, first.Height, ResizeType.NearestNeighbourResample);
                        }

                        // Append the frame to the animation
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the resulting APNG animation
                apngImage.Save();
            }
        }
    }
}