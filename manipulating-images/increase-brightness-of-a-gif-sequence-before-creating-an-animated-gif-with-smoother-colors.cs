using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing GIF frames and output file path
            string inputDirectory = @"C:\temp\frames";
            string outputPath = @"C:\temp\output\animated_bright.gif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get all GIF files in the input directory
            string[] frameFiles = Directory.GetFiles(inputDirectory, "*.gif");

            GifImage resultGif = null;

            foreach (string frameFile in frameFiles)
            {
                // Verify each input file exists
                if (!File.Exists(frameFile))
                {
                    Console.Error.WriteLine($"File not found: {frameFile}");
                    return;
                }

                // Load the GIF frame
                using (GifImage frameGif = (GifImage)Image.Load(frameFile))
                {
                    // Increase brightness (value range: -255 to 255)
                    frameGif.AdjustBrightness(50);

                    if (resultGif == null)
                    {
                        // Create the result GIF using the first frame's active frame block
                        resultGif = new GifImage((GifFrameBlock)frameGif.ActiveFrame);
                    }
                    else
                    {
                        // Add the current frame as a new page to the result GIF
                        resultGif.AddPage((RasterImage)frameGif.ActiveFrame);
                    }
                }
            }

            if (resultGif == null)
            {
                Console.Error.WriteLine("No frames were processed.");
                return;
            }

            // Set palette correction for smoother colors
            GifOptions saveOptions = new GifOptions
            {
                DoPaletteCorrection = true
            };

            // Save the animated GIF
            resultGif.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}