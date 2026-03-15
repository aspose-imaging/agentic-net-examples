using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Animation parameters
        const int AnimationDuration = 1000; // total duration in ms
        const int FrameDuration = 70;       // each frame duration in ms

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load("not_animated.png"))
        {
            // Apply a Gaussian blur filter to transform the pixel data
            sourceImage.Filter(
                sourceImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource("raster_animation.png", false),
                DefaultFrameTime = (uint)FrameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                int numOfFrames = AnimationDuration / FrameDuration;
                int halfFrames = numOfFrames / 2;

                // Add the first frame
                apngImage.AddFrame(sourceImage);

                // Add intermediate frames with gamma adjustment
                for (int i = 1; i < numOfFrames - 1; ++i)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    float gamma = i >= halfFrames ? numOfFrames - i - 1 : i;
                    lastFrame.AdjustGamma(gamma);
                }

                // Add the final frame
                apngImage.AddFrame(sourceImage);

                // Save the animated PNG
                apngImage.Save();
            }
        }
    }
}