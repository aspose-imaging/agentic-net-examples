using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output APNG file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Process each frame of the APNG
            for (int i = 0; i < apng.PageCount; i++)
            {
                // Obtain the current frame as a raster image
                using (RasterImage frame = (RasterImage)apng.Pages[i])
                {
                    // Select a region using MagicWand, feather it, and apply the mask
                    MagicWandTool
                        .Select(frame, new MagicWandSettings(100, 100) { Threshold = 50 })
                        .GetFeathered(new FeatheringSettings() { Size = 2 })
                        .Apply();
                }
            }

            // Save the modified APNG with desired options
            ApngOptions saveOptions = new ApngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 200, // milliseconds per frame
                NumPlays = 0,           // infinite loop
                Source = new StreamSource(new MemoryStream())
            };
            apng.Save(outputPath, saveOptions);
        }
    }
}