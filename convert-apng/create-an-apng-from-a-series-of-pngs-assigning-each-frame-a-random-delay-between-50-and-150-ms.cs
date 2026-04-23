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
        try
        {
            // Hardcoded input PNG file paths
            string[] inputPaths = { "frame1.png", "frame2.png", "frame3.png" };

            // Verify each input file exists
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Hardcoded output APNG path
            string outputPath = "output\\animation.apng";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load first frame to obtain dimensions
            using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = first.Width;
                int height = first.Height;

                // Set up APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create APNG image bound to the output file
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                {
                    apngImage.RemoveAllFrames();

                    Random rnd = new Random();

                    // Add each frame with a random delay between 50 and 150 ms
                    foreach (var path in inputPaths)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(path))
                        {
                            uint delay = (uint)rnd.Next(50, 151); // Upper bound is exclusive
                            apngImage.AddFrame(frame, delay);
                        }
                    }

                    // Save the APNG (output file already bound via FileCreateSource)
                    apngImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}