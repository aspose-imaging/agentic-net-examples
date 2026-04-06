using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hardcoded intermediate TIFF path
        string intermediateTiffPath = @"C:\Images\combined.tif";
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(intermediateTiffPath));

        // Create a TIFF image from the first JPG
        using (Image firstImg = Image.Load(inputPaths[0]))
        {
            // Convert the first image to a TiffFrame
            TiffFrame firstFrame = new TiffFrame((RasterImage)firstImg);
            using (TiffImage tiffImage = new TiffImage(firstFrame))
            {
                // Add remaining JPGs as frames
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (Image img = Image.Load(inputPaths[i]))
                    {
                        TiffFrame frame = new TiffFrame((RasterImage)img);
                        tiffImage.AddFrame(frame);
                    }
                }

                // Save the multi‑frame TIFF
                tiffImage.Save(intermediateTiffPath);
            }
        }

        // Hardcoded final JPG output path
        string outputJpgPath = @"C:\Images\combined.jpg";
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputJpgPath));

        // Load the intermediate TIFF and save as JPG
        using (Image tiff = Image.Load(intermediateTiffPath))
        {
            JpegOptions jpegOptions = new JpegOptions();
            tiff.Save(outputJpgPath, jpegOptions);
        }
    }
}