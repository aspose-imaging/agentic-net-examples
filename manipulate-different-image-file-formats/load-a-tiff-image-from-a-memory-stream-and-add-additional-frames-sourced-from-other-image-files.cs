using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string tiffInputPath = "input.tif";
        string[] additionalImagePaths = new[] { "frame1.png", "frame2.png" };
        string outputPath = "output.tif";

        // Verify the main TIFF input file exists
        if (!File.Exists(tiffInputPath))
        {
            Console.Error.WriteLine($"File not found: {tiffInputPath}");
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

        // Load the original TIFF image from a memory stream
        using (FileStream fileStream = new FileStream(tiffInputPath, FileMode.Open, FileAccess.Read))
        using (MemoryStream memoryStream = new MemoryStream())
        {
            fileStream.CopyTo(memoryStream);
            memoryStream.Position = 0; // Reset stream position for reading

            using (TiffImage tiffImage = (TiffImage)Image.Load(memoryStream))
            {
                // Add each additional image as a new frame
                foreach (var imgPath in additionalImagePaths)
                {
                    // Load the image (e.g., PNG, JPEG) into a RasterImage
                    using (RasterImage raster = (RasterImage)Image.Load(imgPath))
                    {
                        // Create a TiffFrame from the raster image
                        TiffFrame frame = new TiffFrame(raster);
                        // Add the frame to the TIFF image
                        tiffImage.AddFrame(frame);
                        // No need to dispose 'frame' explicitly; it will be disposed with the TiffImage
                    }
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                // Save the updated multi-frame TIFF
                tiffImage.Save(outputPath);
            }
        }
    }
}