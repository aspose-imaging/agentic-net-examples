using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\large.tif";
        string outputPath = @"C:\temp\processed.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source TIFF with a buffer size hint to limit memory usage
        var loadOptions = new LoadOptions { BufferSizeHint = 10 }; // 10 MB buffer

        using (TiffImage sourceTiff = (TiffImage)Image.Load(inputPath, loadOptions))
        {
            // Prepare options for the destination TIFF; the source is bound to the output file
            var createOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                Photometric = TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 }
            };

            // Create the destination TIFF canvas
            using (TiffImage destTiff = (TiffImage)Image.Create(createOptions, sourceTiff.Width, sourceTiff.Height))
            {
                // Process each frame individually to keep memory footprint low
                for (int i = 0; i < sourceTiff.Frames.Length; i++)
                {
                    // Set the active frame
                    sourceTiff.ActiveFrame = sourceTiff.Frames[i];
                    var frame = sourceTiff.ActiveFrame;

                    // Load pixel data for the current frame
                    var bounds = frame.Bounds;
                    var pixels = frame.LoadPixels(bounds);

                    // Simple pixel-wise inversion (memory‑efficient, operates on the loaded array)
                    for (int p = 0; p < pixels.Length; p++)
                    {
                        var c = pixels[p];
                        pixels[p] = Aspose.Imaging.Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                    }

                    // Create a new frame with the same dimensions
                    var newFrame = new TiffFrame(createOptions, frame.Width, frame.Height);
                    // Write the modified pixels into the new frame
                    newFrame.SavePixels(bounds, pixels);
                    // Add the processed frame to the destination TIFF
                    destTiff.AddFrame(newFrame);
                }

                // Save the destination TIFF (output path already bound via FileCreateSource)
                destTiff.Save();
            }
        }
    }
}