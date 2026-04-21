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
        string outputPath = "output_cropped.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load TIFF image from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (Image image = Image.Load(inputStream))
            {
                // Cast to TiffImage to access TIFF-specific methods
                TiffImage tiffImage = (TiffImage)image;

                // Define a 200x200 rectangle (top‑left corner)
                Rectangle cropArea = new Rectangle(0, 0, 200, 200);

                // Crop the image
                tiffImage.Crop(cropArea);

                // Prepare a memory stream to hold the cropped image
                using (MemoryStream outputStream = new MemoryStream())
                {
                    // Save the cropped image into the memory stream using TIFF options
                    TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffImage.Save(outputStream, saveOptions);

                    // Optionally write the memory stream to a file for verification
                    File.WriteAllBytes(outputPath, outputStream.ToArray());

                    // At this point, outputStream contains the cropped TIFF image data
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}