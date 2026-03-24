using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired dimensions for resizing
        int targetWidth = 200;
        int targetHeight = 200;

        // Load the source image (may be animated)
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Prepare APNG creation options
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 100 // default frame duration in ms
            };

            // Create APNG canvas bound to the output file
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, targetWidth, targetHeight))
            {
                // Remove the default empty frame
                apng.RemoveAllFrames();

                // Check if the source image is multipage (animated)
                if (sourceImage is IMultipageImage multipage)
                {
                    foreach (Image page in multipage.Pages)
                    {
                        using (RasterImage frame = (RasterImage)page)
                        {
                            if (!frame.IsCached) frame.CacheData();
                            frame.Resize(targetWidth, targetHeight);
                            apng.AddFrame(frame);
                        }
                    }
                }
                else
                {
                    // Single-frame image
                    using (RasterImage frame = (RasterImage)sourceImage)
                    {
                        if (!frame.IsCached) frame.CacheData();
                        frame.Resize(targetWidth, targetHeight);
                        apng.AddFrame(frame);
                    }
                }

                // Save the APNG (output path already bound)
                apng.Save();
            }
        }
    }
}