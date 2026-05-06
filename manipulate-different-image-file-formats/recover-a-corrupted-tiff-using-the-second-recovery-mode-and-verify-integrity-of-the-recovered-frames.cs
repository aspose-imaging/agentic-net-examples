using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\corrupted.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = @"C:\Images\recovered.tif";
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load with second recovery mode
            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                TiffImage tiff = image as TiffImage;
                if (tiff == null)
                {
                    Console.Error.WriteLine("Loaded image is not a TIFF.");
                    return;
                }

                // Verify integrity of each recovered frame
                int index = 0;
                foreach (var frame in tiff.Frames)
                {
                    // Attempt to load pixels; will throw if frame is invalid
                    var pixels = tiff.LoadPixels(frame.Bounds);
                    Console.WriteLine($"Frame {index}: {frame.Width}x{frame.Height}, Pixels loaded: {pixels.Length}");
                    index++;
                }

                // Save the recovered TIFF
                tiff.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}