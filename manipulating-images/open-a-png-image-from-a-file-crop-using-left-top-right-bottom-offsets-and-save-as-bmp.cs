using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Define crop offsets (left, right, top, bottom)
                int leftOffset = 10;
                int rightOffset = 10;
                int topOffset = 20;
                int bottomOffset = 20;

                // Crop the image using the specified offsets
                image.Crop(leftOffset, rightOffset, topOffset, bottomOffset);

                // Prepare BMP save options (default options are sufficient)
                BmpOptions bmpOptions = new BmpOptions();

                // Save the cropped image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application must convert user‑uploaded PNG screenshots into BMP thumbnails with a fixed border removed, a developer can use this code to load the PNG, crop the unwanted edges, and save the result as BMP.
 * 2. When an automated batch job processes scanned documents stored as PNG files and needs to trim uniform margins before archiving them in BMP format for legacy systems, this snippet provides the required cropping and format conversion.
 * 3. When a game asset pipeline requires extracting a central region from PNG sprites and exporting them as BMP textures for a Windows‑only engine, the code demonstrates how to apply left, top, right, bottom offsets and save the cropped image.
 * 4. When a reporting tool generates PNG charts that must be embedded in a BMP‑based PDF template, a developer can employ this example to remove padding from the chart image and convert it to BMP before insertion.
 * 5. When a Windows service monitors a folder of PNG icons and needs to produce BMP versions with consistent margins for a legacy UI, this code shows how to verify files, crop using offsets, and write the BMP output safely.
 */