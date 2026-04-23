using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"c:\temp\input.dng";
            string outputPath = @"c:\temp\output.jp2";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage to access raw-specific features if needed
                DngImage dngImage = (DngImage)image;

                // Prepare JPEG2000 save options
                Jpeg2000Options saveOptions = new Jpeg2000Options
                {
                    // Use lossless compression (default DWT 5-3)
                    Irreversible = false,
                    // Preserve original metadata
                    KeepMetadata = true
                };

                // Save the image as JPEG2000
                dngImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}