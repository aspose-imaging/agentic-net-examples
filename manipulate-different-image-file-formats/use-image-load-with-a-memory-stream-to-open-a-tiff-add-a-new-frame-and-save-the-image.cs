using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (unconditional call)
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

        // Load the TIFF image from a memory stream
        byte[] fileBytes = File.ReadAllBytes(inputPath);
        using (var memoryStream = new MemoryStream(fileBytes))
        {
            using (var loadedImage = Image.Load(memoryStream))
            {
                // Cast to TiffImage to work with frames
                var tiffImage = loadedImage as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The provided file is not a TIFF image.");
                    return;
                }

                // Define options for the new frame
                var frameOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    Photometric = TiffPhotometrics.Rgb,
                    Compression = TiffCompressions.None
                };

                // Create a new blank frame (100x100 pixels)
                using (var newFrame = new TiffFrame(frameOptions, 100, 100))
                {
                    // Optional: fill the frame with a background color
                    var graphics = new Aspose.Imaging.Graphics(newFrame);
                    graphics.Clear(Aspose.Imaging.Color.LightGray);

                    // Add the new frame to the TIFF image
                    tiffImage.AddFrame(newFrame);
                }

                // Save the modified TIFF to the output path
                tiffImage.Save(outputPath);
            }
        }
    }
}