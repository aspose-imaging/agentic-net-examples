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
        // Input raster image and output APNG paths
        string inputRasterPath = "not_animated.png";
        string outputApngPath = "raster_animation.apng";

        Console.WriteLine("Loading raster image...");
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputRasterPath))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputApngPath, false),
                DefaultFrameTime = 70, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            Console.WriteLine("Creating APNG image...");
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add frames (using the same source image for demonstration)
                apngImage.AddFrame(sourceImage);
                apngImage.AddFrame(sourceImage);

                // Save the APNG (output file is already bound via FileCreateSource)
                apngImage.Save();
                Console.WriteLine($"APNG saved to '{outputApngPath}'.");
            }
        }

        // Open the created APNG and re-save with a different frame duration
        Console.WriteLine("Loading created APNG for re-export...");
        using (ApngImage loadedApng = (ApngImage)Image.Load(outputApngPath))
        {
            ApngOptions exportOptions = new ApngOptions
            {
                DefaultFrameTime = 100 // faster animation
            };
            string exportedApngPath = "exported_animation.apng";

            loadedApng.Save(exportedApngPath, exportOptions);
            Console.WriteLine($"Re-exported APNG saved to '{exportedApngPath}'.");
        }
    }
}