using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input TIFF file paths
        string[] inputPaths = {
            "C:\\Images\\input1.tif",
            "C:\\Images\\input2.tif",
            "C:\\Images\\input3.tif"
        };

        // Corresponding output APNG file paths
        string[] outputPaths = {
            "C:\\Images\\output1.apng",
            "C:\\Images\\output2.apng",
            "C:\\Images\\output3.apng"
        };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image (may contain multiple frames)
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int width = tiffImage.Width;
                int height = tiffImage.Height;

                // Compute default frame time based on dimensions (example logic)
                uint defaultFrameTime = (uint)((width + height) / 20);
                if (defaultFrameTime == 0) defaultFrameTime = 100; // fallback to 100 ms

                // Prepare APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = defaultFrameTime,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create APNG image bound to the output file
                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    // Remove the default single frame
                    apngImage.RemoveAllFrames();

                    // Add each TIFF frame to the APNG
                    foreach (TiffFrame frame in tiffImage.Frames)
                    {
                        // Cast frame to RasterImage and add as a new frame
                        apngImage.AddFrame((RasterImage)frame);
                    }

                    // Save the APNG (output path already bound via FileCreateSource)
                    apngImage.Save();
                }
            }
        }
    }
}