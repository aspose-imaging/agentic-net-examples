using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.dng";
        string outputPath = @"C:\temp\output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DNG image with default load options (demosaicing is performed automatically)
        using (Image image = Image.Load(inputPath, new DngLoadOptions()))
        {
            // Cast to DngImage to access raw-specific features if needed
            DngImage dngImage = (DngImage)image;

            // Prepare JPEG2000 save options for lossless compression (default)
            Jpeg2000Options saveOptions = new Jpeg2000Options
            {
                // Irreversible = false ensures lossless DWT 5-3 compression (default value)
                Irreversible = false
            };

            // Save the demosaiced image as JPEG2000
            dngImage.Save(outputPath, saveOptions);
        }
    }
}