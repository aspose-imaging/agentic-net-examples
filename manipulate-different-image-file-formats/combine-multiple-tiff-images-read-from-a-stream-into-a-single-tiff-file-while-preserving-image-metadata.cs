using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input TIFF files (replace with actual paths or streams)
            string[] inputPaths = new string[]
            {
                "input1.tif",
                "input2.tif",
                "input3.tif"
            };

            // Output combined TIFF file
            string outputPath = "combined.tif";

            // Load the first image to obtain dimensions and basic options
            using (TiffImage firstImage = (TiffImage)Image.Load(inputPaths[0]))
            {
                // Prepare TiffOptions for the output file
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                tiffOptions.Compression = TiffCompressions.Lzw;

                // Create the output TIFF canvas using the dimensions of the first frame
                using (TiffImage outputTiff = (TiffImage)Image.Create(tiffOptions, firstImage.ActiveFrame.Width, firstImage.ActiveFrame.Height))
                {
                    // Add frames from each input TIFF
                    foreach (string path in inputPaths)
                    {
                        using (TiffImage src = (TiffImage)Image.Load(path))
                        {
                            // Preserve metadata by adding the whole image (its frames) to the output
                            outputTiff.Add(src);
                        }
                    }

                    // Remove the initially created default frame
                    TiffFrame defaultFrame = outputTiff.ActiveFrame;
                    if (outputTiff.Frames.Length > 1)
                    {
                        outputTiff.ActiveFrame = outputTiff.Frames[1];
                        outputTiff.RemoveFrame(0);
                    }
                    defaultFrame.Dispose();

                    // Save the combined TIFF
                    outputTiff.Save();
                }
            }
        }
    }
}