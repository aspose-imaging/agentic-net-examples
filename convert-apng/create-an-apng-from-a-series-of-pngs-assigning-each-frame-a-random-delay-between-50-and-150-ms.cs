using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input PNG file paths
        string[] inputPaths = { "frame1.png", "frame2.png", "frame3.png" };
        // Hardcoded output APNG file path
        string outputPath = "output_animation.apng";

        // Verify each input file exists
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Random generator for frame delays (50‑150 ms)
        Random rnd = new Random();

        // Load the first image to obtain canvas size
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            int width = firstImage.Width;
            int height = firstImage.Height;

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
            {
                // Remove the default frame
                apngImage.RemoveAllFrames();

                // Add the first frame with a random delay
                int delay = rnd.Next(50, 151); // Upper bound exclusive
                apngImage.AddFrame(firstImage, (uint)delay);

                // Add remaining frames
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        int frameDelay = rnd.Next(50, 151);
                        apngImage.AddFrame(img, (uint)frameDelay);
                    }
                }

                // Save the APNG file
                apngImage.Save();
            }
        }
    }
}