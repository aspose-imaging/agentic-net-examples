using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input TIFF path
            string inputPath = @"C:\Images\input.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for BMP frames
            string outputDir = @"C:\Images\Frames";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access frames
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not a TIFF image.");
                    return;
                }

                // Iterate through each frame and save as BMP
                TiffFrame[] frames = tiffImage.Frames;
                for (int i = 0; i < frames.Length; i++)
                {
                    // Build output file path for the current frame
                    string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Export the frame to BMP using default BmpOptions
                    BmpOptions bmpOptions = new BmpOptions();
                    frames[i].Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}