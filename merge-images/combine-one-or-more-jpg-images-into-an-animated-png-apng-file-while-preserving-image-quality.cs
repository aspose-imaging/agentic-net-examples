using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect at least two arguments: input JPG files followed by output APNG file path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input1.jpg> <input2.jpg> ... <output.apng>");
            return;
        }

        // Last argument is the output file, the rest are input images
        string outputPath = args[args.Length - 1];
        var inputPaths = new List<string>();
        for (int i = 0; i < args.Length - 1; i++)
        {
            inputPaths.Add(args[i]);
        }

        // Load the first image to obtain canvas dimensions
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            int canvasWidth = firstImage.Width;
            int canvasHeight = firstImage.Height;

            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, canvasWidth, canvasHeight))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add each JPG image as a frame
                foreach (string path in inputPaths)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(path))
                    {
                        // Ensure frame size matches canvas; resize if necessary
                        if (frame.Width != canvasWidth || frame.Height != canvasHeight)
                        {
                            frame.Resize(canvasWidth, canvasHeight, ResizeType.NearestNeighbourResample);
                        }

                        apngImage.AddFrame(frame);
                    }
                }

                // Save the animated PNG (output is already bound to the source)
                apngImage.Save();
            }
        }
    }
}