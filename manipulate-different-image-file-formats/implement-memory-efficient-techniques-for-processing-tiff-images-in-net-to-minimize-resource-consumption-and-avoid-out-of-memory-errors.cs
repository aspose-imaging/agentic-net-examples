using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output TIFF file paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // LoadOptions with a buffer size hint to limit memory usage (e.g., 64 MB)
        var loadOptions = new LoadOptions { BufferSizeHint = 64 };

        // Open the source multi‑page TIFF using a using block for proper disposal
        using (TiffImage sourceTiff = (TiffImage)Image.Load(inputPath, loadOptions))
        {
            // Configure options for the output TIFF
            var outputOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                Photometric = TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 }
            };

            // Create the output TIFF with the same dimensions as the source
            using (TiffImage outputTiff = (TiffImage)Image.Create(outputOptions, sourceTiff.Width, sourceTiff.Height))
            {
                // Process each frame individually to avoid loading the whole document into memory
                for (int i = 0; i < sourceTiff.Frames.Length; i++)
                {
                    // Get the current frame from the source TIFF
                    TiffFrame srcFrame = sourceTiff.Frames[i];

                    // Load pixel data for the current frame only
                    Color[] pixels = sourceTiff.LoadPixels(srcFrame.Bounds);

                    if (i == 0)
                    {
                        // The output TIFF already contains a default frame; replace its pixels
                        outputTiff.ActiveFrame.SavePixels(outputTiff.ActiveFrame.Bounds, pixels);
                    }
                    else
                    {
                        // Create a new frame for the output TIFF with the same size as the source frame
                        var newFrame = new TiffFrame(outputOptions, srcFrame.Width, srcFrame.Height);
                        newFrame.SavePixels(newFrame.Bounds, pixels);
                        // Add the new frame to the output TIFF
                        outputTiff.AddFrame(newFrame);
                    }

                    // Optional: release pixel array reference early
                    pixels = null;
                }

                // Save the output TIFF; all frames have been added and processed
                outputTiff.Save();
            }
        }
    }
}