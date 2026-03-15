using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input TIFF path (first argument) and output directory (second argument)
        string inputPath = args.Length > 0 ? args[0] : "input.tif";
        string outputDir = args.Length > 1 ? args[1] : "output_frames";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the multi-frame TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Iterate over each frame
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                // Create an independent copy of the current frame
                TiffFrame frameCopy = TiffFrame.CopyFrame(tiffImage.Frames[i]);

                // Create a new TIFF image containing only this frame
                using (TiffImage singleFrameTiff = new TiffImage(frameCopy))
                {
                    // Define output file path for the current frame
                    string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.tif");

                    // Save the single-frame TIFF using default options
                    singleFrameTiff.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                }
            }
        }
    }
}