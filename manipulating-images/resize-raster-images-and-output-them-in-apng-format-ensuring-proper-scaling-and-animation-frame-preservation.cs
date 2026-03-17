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
        // Expected arguments: inputPath outputPath targetWidth targetHeight
        if (args.Length != 4)
        {
            Console.WriteLine("Usage: <inputPath> <outputPath> <targetWidth> <targetHeight>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        int targetWidth = int.Parse(args[2]);
        int targetHeight = int.Parse(args[3]);

        // Load the source image (could be single-frame or multi-frame)
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Prepare APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default frame duration in ms
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas with the desired size
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, targetWidth, targetHeight))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Check if the source image supports multiple pages/frames
                if (sourceImage is IMultipageImage multipage)
                {
                    // Iterate through each frame/page
                    foreach (var page in multipage.Pages)
                    {
                        using (RasterImage frame = (RasterImage)page)
                        {
                            if (!frame.IsCached) frame.CacheData();
                            frame.Resize(targetWidth, targetHeight);
                            apngImage.AddFrame(frame);
                        }
                    }
                }
                else
                {
                    // Single-frame image handling
                    using (RasterImage raster = (RasterImage)sourceImage)
                    {
                        if (!raster.IsCached) raster.CacheData();
                        raster.Resize(targetWidth, targetHeight);
                        apngImage.AddFrame(raster);
                    }
                }

                // Save the APNG file (output is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}