using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.apng";
        string outputPath = args.Length > 1 ? args[1] : "output.apng";

        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            for (int i = 0; i < apng.PageCount; i++)
            {
                ApngFrame frame = (ApngFrame)apng.Pages[i];
                frame.FrameTime = 100;
                frame.AdjustGamma(1.2f);
            }

            using (RasterImage newFrame = (RasterImage)Image.Load("new_frame.png"))
            {
                apng.AddFrame(newFrame);
            }

            apng.Save(outputPath);
        }
    }
}