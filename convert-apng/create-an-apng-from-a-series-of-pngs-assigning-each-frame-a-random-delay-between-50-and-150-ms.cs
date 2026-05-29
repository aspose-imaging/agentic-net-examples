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
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Hardcoded output APNG path (includes a directory)
            string outputPath = "output\\animation.apng";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first image to obtain canvas dimensions
            using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = first.Width;
                int height = first.Height;

                // Configure APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG canvas bound to the output file
                using (ApngImage apng = (ApngImage)Image.Create(createOptions, width, height))
                {
                    // Remove the default single frame
                    apng.RemoveAllFrames();

                    Random rnd = new Random();

                    // Add each PNG as a frame with a random delay between 50 and 150 ms
                    foreach (string path in inputPaths)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(path))
                        {
                            uint delay = (uint)rnd.Next(50, 151); // Random delay in ms
                            apng.AddFrame(frame, delay);
                        }
                    }

                    // Save the bound APNG image
                    apng.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}