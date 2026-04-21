using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hard‑coded input and output file paths.
            string inputPath = @"c:\temp\input.dng";
            string outputPath = @"c:\temp\output.jp2";

            // Verify that the input DNG file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage to access DNG‑specific features if needed.
                DngImage dngImage = (DngImage)image;

                // Prepare JPEG2000 save options.
                Jpeg2000Options jpeg2000Options = new Jpeg2000Options
                {
                    // Use lossless compression (default is lossless, but set explicitly for clarity).
                    Irreversible = false,
                    // Preserve original metadata in the output file.
                    KeepMetadata = true
                };

                // Save the image as JPEG2000 using the configured options.
                dngImage.Save(outputPath, jpeg2000Options);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors without crashing the application.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}