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
        // Expect at least one output path followed by one or more input JPG paths
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <output.apng> <input1.jpg> [<input2.jpg> ...]");
            return;
        }

        string outputPath = args[0];
        string[] inputPaths = new string[args.Length - 1];
        Array.Copy(args, 1, inputPaths, 0, inputPaths.Length);

        // Determine canvas size (maximum width and height among all input images)
        int maxWidth = 0;
        int maxHeight = 0;
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                if (img.Width > maxWidth) maxWidth = img.Width;
                if (img.Height > maxHeight) maxHeight = img.Height;
            }
        }

        // Set up APNG creation options
        ApngOptions createOptions = new ApngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            DefaultFrameTime = 100, // default frame duration in milliseconds
            ColorType = PngColorType.TruecolorWithAlpha
        };

        // Create the APNG canvas with the calculated size
        using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, maxWidth, maxHeight))
        {
            // Remove the default empty frame
            apngImage.RemoveAllFrames();

            // Add each JPG image as a frame
            foreach (string path in inputPaths)
            {
                using (RasterImage frame = (RasterImage)Image.Load(path))
                {
                    apngImage.AddFrame(frame);
                }
            }

            // Save the bound APNG file
            apngImage.Save();
        }
    }
}