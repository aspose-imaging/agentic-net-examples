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
            string inputTiffPath = "input.tif";
            string[] additionalImagePaths = new string[] { "frame1.png", "frame2.jpg" };
            string outputTiffPath = "output\\result.tif";

            // Verify the base TIFF file exists
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }

            // Verify each additional image file exists
            foreach (var path in additionalImagePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Load the base TIFF image from a memory stream
            byte[] tiffBytes = File.ReadAllBytes(inputTiffPath);
            using (MemoryStream memoryStream = new MemoryStream(tiffBytes))
            {
                using (TiffImage tiffImage = (TiffImage)Image.Load(memoryStream))
                {
                    // Add each additional image as a new frame
                    foreach (var imgPath in additionalImagePaths)
                    {
                        // Create a TiffFrame directly from the image file
                        TiffFrame frame = new TiffFrame(imgPath);
                        tiffImage.AddFrame(frame);
                    }

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

                    // Save the multi‑frame TIFF
                    tiffImage.Save(outputTiffPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}