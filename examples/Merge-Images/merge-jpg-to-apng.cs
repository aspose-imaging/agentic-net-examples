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
        // Input JPG files to be merged into an APNG animation
        string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Output APNG file
        string outputPath = "merged.apng";

        // Load the first image to obtain canvas dimensions
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            int canvasWidth = firstImage.Width;
            int canvasHeight = firstImage.Height;

            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 500, // 500 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, canvasWidth, canvasHeight))
            {
                // Ensure the canvas starts with no frames
                apngImage.RemoveAllFrames();

                // Add each JPG as a frame
                foreach (string path in inputPaths)
                {
                    using (RasterImage frameImage = (RasterImage)Image.Load(path))
                    {
                        // If dimensions differ, resize to match canvas
                        if (frameImage.Width != canvasWidth || frameImage.Height != canvasHeight)
                        {
                            frameImage.Resize(canvasWidth, canvasHeight, ResizeType.NearestNeighbourResample);
                        }

                        apngImage.AddFrame(frameImage);
                    }
                }

                // Save the APNG animation
                apngImage.Save();
            }
        }
    }
}