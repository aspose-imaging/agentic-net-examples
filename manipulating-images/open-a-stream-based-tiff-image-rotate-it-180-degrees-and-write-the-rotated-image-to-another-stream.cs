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
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Open the input file as a stream
        using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        {
            // Load the TIFF image from the input stream
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputStream))
            {
                // Rotate the image 180 degrees around its centre.
                // resizeProportionally = true to adjust canvas size,
                // background colour set to white.
                tiffImage.Rotate(180f, true, Color.White);

                // Open the output file as a stream
                using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    // Save the rotated image to the output stream using default TIFF options
                    tiffImage.Save(outputStream, new TiffOptions(TiffExpectedFormat.Default));
                }
            }
        }
    }
}