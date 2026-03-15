using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source animated image (e.g., GIF, WebP, multi‑page TIFF)
        string sourcePath = "input_animation.gif";

        // Desired output path for the APNG file
        string outputPath = "output_animation.apng";

        // Load the source image – this preserves all frames and transparency
        using (Image sourceImage = Image.Load(sourcePath))
        {
            // Configure APNG specific options.
            // DefaultFrameTime can be set to override frame duration,
            // NumPlays = 0 means infinite looping (default behavior).
            var apngOptions = new ApngOptions
            {
                // Example: set a uniform frame duration of 100 ms
                // DefaultFrameTime = 100,

                // Example: limit the animation to 5 loops
                // NumPlays = 5
            };

            // Save the loaded image directly to APNG format.
            // Aspose.Imaging handles the conversion, preserving animation frames
            // and any alpha channel (transparency) present in the source.
            sourceImage.Save(outputPath, apngOptions);
        }
    }
}