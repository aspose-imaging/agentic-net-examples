using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

namespace WmfCropExample
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.wmf";
            string outputPath = @"C:\Images\output_cropped.wmf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to WmfImage to access WMF-specific methods
                WmfImage wmfImage = (WmfImage)image;

                // Define the rectangle to crop (x, y, width, height)
                // Adjust these values as needed for the desired crop area
                Rectangle cropArea = new Rectangle(50, 50, 200, 200);

                // Perform the crop operation
                wmfImage.Crop(cropArea);

                // Save the cropped image, preserving WMF format and metadata
                wmfImage.Save(outputPath);
            }
        }
    }
}