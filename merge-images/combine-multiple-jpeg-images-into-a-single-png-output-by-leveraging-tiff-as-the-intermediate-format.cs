using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG files and output PNG file
        string[] inputPaths = new[] { "image1.jpg", "image2.jpg", "image3.jpg" };
        string outputPath = "combined.png";

        // Validate each input file exists
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the first JPEG and create a TIFF image with its frame
        using (RasterImage firstImg = (RasterImage)Image.Load(inputPaths[0]))
        {
            var firstFrame = new TiffFrame(firstImg);
            using (TiffImage tiffImage = new TiffImage(firstFrame))
            {
                // Add remaining JPEGs as additional frames
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        var frame = new TiffFrame(img);
                        tiffImage.AddFrame(frame);
                    }
                }

                // Save the multi‑frame TIFF as a single PNG image
                tiffImage.Save(outputPath, new PngOptions());
            }
        }
    }
}