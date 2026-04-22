using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame and set resolution based on its dimensions
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Make the current frame active
                    tiffImage.ActiveFrame = tiffImage.Frames[i];

                    // Example logic: higher resolution for larger frames
                    if (tiffImage.ActiveFrame.Width > 1000 || tiffImage.ActiveFrame.Height > 1000)
                    {
                        tiffImage.HorizontalResolution = 300; // DPI
                        tiffImage.VerticalResolution = 300;
                    }
                    else
                    {
                        tiffImage.HorizontalResolution = 150;
                        tiffImage.VerticalResolution = 150;
                    }
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified TIFF
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}