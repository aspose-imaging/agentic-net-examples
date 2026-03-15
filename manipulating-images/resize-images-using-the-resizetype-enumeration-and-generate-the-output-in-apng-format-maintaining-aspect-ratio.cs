using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // args[0] - input image path
        // args[1] - output APNG path
        // args[2] - desired width (int)
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <inputPath> <outputPath> <targetWidth>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        int targetWidth = int.Parse(args[2]);

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Calculate new height to maintain aspect ratio
            int newHeight = (int)((double)sourceImage.Height * targetWidth / sourceImage.Width);

            // Resize using specified ResizeType
            sourceImage.Resize(targetWidth, newHeight, ResizeType.LanczosResample);

            // Prepare APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 500 // 500 ms per frame
            };

            // Create APNG image and add the resized frame
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                apngImage.RemoveAllFrames();
                apngImage.AddFrame(sourceImage);
                apngImage.Save();
            }
        }
    }
}