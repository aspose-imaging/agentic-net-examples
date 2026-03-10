using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Load a source image (any format supported by Aspose.Imaging)
        using (Image image = Image.Load("input.png"))
        {
            // Configure APNG options:
            // - DefaultFrameTime sets the duration of each frame in milliseconds.
            // - NumPlays = 0 means the animation will loop infinitely (default).
            var apngOptions = new ApngOptions
            {
                DefaultFrameTime = 500, // 500 ms per frame
                NumPlays = 0            // infinite looping
            };

            // Save the image as an animated PNG (APNG). The .png extension is used for APNG files.
            image.Save("output.png", apngOptions);
        }
    }
}