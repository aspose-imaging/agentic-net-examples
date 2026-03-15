using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the source image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Resize the image to 200x200 pixels
            sourceImage.Resize(200, 200);
            // Rotate the image 45 degrees, filling empty areas with white
            sourceImage.Rotate(45f, true, Color.White);

            // Configure APNG creation options
            using (ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            })
            {
                // Create a new APNG image bound to the output file
                using (Aspose.Imaging.FileFormats.Apng.ApngImage apngImage = (Aspose.Imaging.FileFormats.Apng.ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Remove the default single frame
                    apngImage.RemoveAllFrames();

                    // Add the first frame (the transformed source image)
                    apngImage.AddFrame(sourceImage);

                    // Add additional frames with varying gamma adjustments to create animation
                    for (int i = 1; i <= 4; i++)
                    {
                        apngImage.AddFrame(sourceImage);
                        var frame = (Aspose.Imaging.FileFormats.Apng.ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                        frame.AdjustGamma(0.5f + i * 0.1f);
                    }

                    // Save the APNG image (the file is already bound via FileCreateSource)
                    apngImage.Save();
                }
            }
        }
    }
}