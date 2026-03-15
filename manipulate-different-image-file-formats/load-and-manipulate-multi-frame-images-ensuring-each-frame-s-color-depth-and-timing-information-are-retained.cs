using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputPath> <outputPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the source image (could be GIF, APNG, or any multipage format)
        using (Image srcImage = Image.Load(inputPath))
        {
            // Verify that the loaded image supports multiple pages/frames
            if (srcImage is IMultipageImage multipage)
            {
                int width = srcImage.Width;
                int height = srcImage.Height;

                // Prepare options for creating the APNG output
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create a new APNG image with the same dimensions as the source
                using (ApngImage apng = (ApngImage)Image.Create(createOptions, width, height))
                {
                    // Remove the default empty frame
                    apng.RemoveAllFrames();

                    // Iterate through each frame of the source image
                    foreach (var page in multipage.Pages)
                    {
                        // Attempt to obtain a raster representation of the frame
                        RasterImage frame = page as RasterImage;
                        if (frame == null)
                        {
                            // If the page is not a raster image, skip it (vector frames would need rasterization)
                            continue;
                        }

                        // Add the raster frame to the APNG
                        apng.AddFrame(frame);

                        // Retrieve the newly added APNG frame to copy timing information
                        ApngFrame addedFrame = (ApngFrame)apng.Pages[apng.PageCount - 1];

                        // Preserve original frame duration when possible
                        if (page is ApngFrame srcApngFrame)
                        {
                            addedFrame.FrameTime = srcApngFrame.FrameTime;
                        }
                        // For GIF frames, the delay can be accessed via the GifFrameBlock's Delay property,
                        // but for simplicity we keep the default duration.
                    }

                    // Save the resulting APNG; since the source was bound to a FileCreateSource,
                    // calling Save() writes directly to the output file.
                    apng.Save();
                }
            }
            else
            {
                Console.WriteLine("The provided image does not contain multiple frames.");
            }
        }
    }
}