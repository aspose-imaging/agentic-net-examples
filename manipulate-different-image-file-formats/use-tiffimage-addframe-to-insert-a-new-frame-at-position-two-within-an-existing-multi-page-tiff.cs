using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputTiffPath = @"C:\temp\input.tif";
        string newFrameImagePath = @"C:\temp\newframe.png";
        string outputTiffPath = @"C:\temp\output.tif";

        // Verify input TIFF exists
        if (!File.Exists(inputTiffPath))
        {
            Console.Error.WriteLine($"File not found: {inputTiffPath}");
            return;
        }

        // Verify new frame image exists
        if (!File.Exists(newFrameImagePath))
        {
            Console.Error.WriteLine($"File not found: {newFrameImagePath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

        // Load the existing multi‑page TIFF
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputTiffPath))
        {
            // Create a TiffFrame from the new image file
            TiffFrame newFrame = new TiffFrame(newFrameImagePath);

            // Insert the new frame at position index 2 (third position)
            tiffImage.InsertFrame(2, newFrame);

            // Save the modified TIFF to the output path
            tiffImage.Save(outputTiffPath);
        }
    }
}