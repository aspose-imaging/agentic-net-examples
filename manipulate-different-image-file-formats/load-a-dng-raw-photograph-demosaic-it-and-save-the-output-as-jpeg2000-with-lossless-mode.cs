using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;

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

        try
        {
            // Load the DNG image (demosaicing is performed automatically)
            using (Image image = Image.Load(inputPath, new Aspose.Imaging.ImageLoadOptions.DngLoadOptions()))
            {
                DngImage dngImage = (DngImage)image;

                // Prepare JPEG2000 save options (default is lossless)
                Jpeg2000Options jpeg2000Options = new Jpeg2000Options();

                // Save as JPEG2000 lossless
                dngImage.Save(outputPath, jpeg2000Options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}