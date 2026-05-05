using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;

class Program
{
    // Hardcoded input and output file paths
    private const string InputPath = "input.png";
    private const string OutputPath = "output.png";

    static void Main()
    {
        try
        {
            // Verify input file exists
            if (!File.Exists(InputPath))
            {
                Console.Error.WriteLine($"File not found: {InputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));

            // Load the image file into a byte array
            byte[] imageData = File.ReadAllBytes(InputPath);

            // Example parameters for MagicWandTool
            int referenceX = 120;   // X coordinate of reference point
            int referenceY = 100;   // Y coordinate of reference point
            int threshold   = 150; // Tolerance level

            // Process the image and obtain the result as a stream
            using (MemoryStream resultStream = ProcessImage(imageData, referenceX, referenceY, threshold))
            {
                // Write the resulting stream to the output file
                using (FileStream fileOut = new FileStream(OutputPath, FileMode.Create, FileAccess.Write))
                {
                    resultStream.CopyTo(fileOut);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads an image from a byte array, applies MagicWandTool with the specified settings,
    /// and returns the processed image as a MemoryStream (PNG format).
    /// </summary>
    /// <param name="imageBytes">Byte array containing the source image.</param>
    /// <param name="x">X coordinate of the reference point for MagicWandTool.</param>
    /// <param name="y">Y coordinate of the reference point for MagicWandTool.</param>
    /// <param name="threshold">Threshold value for color tolerance.</param>
    /// <returns>MemoryStream containing the processed image.</returns>
    private static MemoryStream ProcessImage(byte[] imageBytes, int x, int y, int threshold)
    {
        // Prepare a memory stream from the input byte array
        using (MemoryStream inputStream = new MemoryStream(imageBytes))
        {
            // Load the image from the stream
            using (Image img = Image.Load(inputStream))
            {
                // Cast to RasterImage to work with MagicWandTool
                using (RasterImage raster = (RasterImage)img)
                {
                    // Create MagicWandSettings with the reference point and threshold
                    MagicWandSettings settings = new MagicWandSettings(x, y) { Threshold = threshold };

                    // Generate a mask using MagicWandTool and apply it to the image
                    MagicWandTool.Select(raster, settings).Apply();

                    // Save the processed image to a new memory stream (PNG format)
                    MemoryStream outputStream = new MemoryStream();
                    raster.Save(outputStream, new PngOptions());
                    outputStream.Position = 0; // Reset position for reading
                    return outputStream;
                }
            }
        }
    }
}