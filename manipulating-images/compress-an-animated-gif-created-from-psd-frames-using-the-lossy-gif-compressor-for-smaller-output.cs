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
            // Hardcoded input directory containing PSD frames and output file path
            string inputDirectory = @"C:\Input\PsdFrames";
            string outputPath = @"C:\Output\animated_lossy.gif";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Get all PSD files in the directory
            string[] psdFiles = Directory.GetFiles(inputDirectory, "*.psd");
            if (psdFiles.Length == 0)
            {
                Console.Error.WriteLine("No PSD files found in the input directory.");
                return;
            }

            // Load the first frame and create the GIF image
            string firstFile = psdFiles[0];
            if (!File.Exists(firstFile))
            {
                Console.Error.WriteLine($"File not found: {firstFile}");
                return;
            }

            using (RasterImage firstImage = (RasterImage)Image.Load(firstFile))
            using (GifImage gifImage = new GifImage(new GifFrameBlock(firstImage)))
            {
                // Add remaining frames to the GIF
                for (int i = 1; i < psdFiles.Length; i++)
                {
                    string framePath = psdFiles[i];
                    if (!File.Exists(framePath))
                    {
                        Console.Error.WriteLine($"File not found: {framePath}");
                        continue; // skip missing file
                    }

                    using (RasterImage frameImage = (RasterImage)Image.Load(framePath))
                    {
                        gifImage.AddPage(frameImage);
                    }
                }

                // Prepare lossy GIF save options
                var saveOptions = new GifOptions
                {
                    MaxDiff = 80 // enable lossy compression
                };

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the animated GIF with lossy compression
                gifImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}