using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output\cropped.tif";

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

            // Crop a 200x200 rectangle from the top‑left corner
            var cropRect = new Aspose.Imaging.Rectangle(0, 0, 200, 200);
            tiffImage.Crop(cropRect);

            // Save the cropped image to a memory stream
            using (MemoryStream outputStream = new MemoryStream())
            {
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffImage.Save(outputStream, saveOptions);

                // The memory stream now contains the cropped TIFF data.
                // Example: write to a file if needed
                // File.WriteAllBytes(outputPath, outputStream.ToArray());
            }
        }
    }
}