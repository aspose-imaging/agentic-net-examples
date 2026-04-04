using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\sample_aligned.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access AlignResolutions
            if (image is TiffImage tiffImage)
            {
                // Capture resolutions before alignment
                double beforeH = tiffImage.HorizontalResolution;
                double beforeV = tiffImage.VerticalResolution;
                Console.WriteLine($"Before AlignResolutions - Horizontal DPI: {beforeH}, Vertical DPI: {beforeV}");

                // Align resolutions for the whole image
                tiffImage.AlignResolutions();

                // Align resolutions for each frame (optional but ensures all frames are consistent)
                foreach (TiffFrame frame in tiffImage.Frames)
                {
                    frame.AlignResolutions();
                }

                // Capture resolutions after alignment
                double afterH = tiffImage.HorizontalResolution;
                double afterV = tiffImage.VerticalResolution;
                Console.WriteLine($"After AlignResolutions - Horizontal DPI: {afterH}, Vertical DPI: {afterV}");

                // Validate that horizontal and vertical DPI are now identical
                if (Math.Abs(afterH - afterV) < 0.0001)
                {
                    Console.WriteLine("Success: Horizontal and vertical DPI are identical after alignment.");
                }
                else
                {
                    Console.WriteLine("Failure: DPI values differ after alignment.");
                }

                // Save the aligned image
                tiffImage.Save(outputPath);
                Console.WriteLine($"Aligned image saved to: {outputPath}");
            }
            else
            {
                Console.Error.WriteLine("The loaded image is not a TIFF image.");
            }
        }
    }
}