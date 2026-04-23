using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.apng";
            string outputPath = "output\\output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG animation
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF export options with palette correction (limits to 256 colors)
                var gifOptions = new GifOptions
                {
                    DoPaletteCorrection = true,
                    // Optional: set color resolution (7 means 8 bits per channel, suitable for GIF)
                    ColorResolution = 7
                };

                // Save the image as a GIF using the configured options
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}