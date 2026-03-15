using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        const string inputPath = "input.png";
        const string outputPath = "output.apng";

        const int animationDuration = 1000; // total animation duration in ms
        const int frameDuration = 100; // base frame duration in ms

        using (RasterImage source = (RasterImage)Image.Load(inputPath))
        {
            ApngOptions options = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)frameDuration,
                ColorType = PngColorType.TruecolorWithAlpha,
                NumPlays = 0 // infinite looping by default
            };

            using (ApngImage apng = (ApngImage)Image.Create(options, source.Width, source.Height))
            {
                apng.DefaultFrameTime = (uint)frameDuration;
                apng.NumPlays = 3; // play the animation three times

                apng.RemoveAllFrames();

                int frameCount = animationDuration / frameDuration;

                for (int i = 0; i < frameCount; i++)
                {
                    uint customTime = (i % 2 == 0) ? (uint)frameDuration : (uint)(frameDuration * 2);
                    apng.AddFrame(source, customTime);
                }

                apng.Save();
            }
        }
    }
}