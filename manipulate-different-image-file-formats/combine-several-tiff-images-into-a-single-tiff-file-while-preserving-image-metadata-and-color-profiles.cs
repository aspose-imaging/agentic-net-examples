using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class TiffCombiner
{
    static void Main()
    {
        // Paths of source TIFF files to be combined
        string[] sourceFiles = new string[]
        {
            @"C:\Images\page1.tif",
            @"C:\Images\page2.tif",
            @"C:\Images\page3.tif"
        };

        // Destination path for the combined multi‑page TIFF
        string outputFile = @"C:\Images\combined.tif";

        // Load the first TIFF – it will become the base image that receives the other frames
        using (TiffImage combined = (TiffImage)Image.Load(sourceFiles[0]))
        {
            // Preserve original metadata of the base image (already retained after load)

            // Iterate over the remaining TIFF files and add their frames to the base image
            for (int i = 1; i < sourceFiles.Length; i++)
            {
                // Load the next TIFF image
                using (TiffImage next = (TiffImage)Image.Load(sourceFiles[i]))
                {
                    // Add all frames from the loaded image into the combined image
                    combined.Add(next);

                    // Optional: preserve metadata of the added image by copying it to the newly added frames
                    // (metadata is usually kept when using Add, but explicit copy can be done if needed)
                    // foreach (var frame in next.Frames)
                    // {
                    //     combined.TrySetMetadata(frame.Metadata);
                    // }
                }
            }

            // Save the resulting multi‑page TIFF while keeping all metadata and color profiles
            combined.Save(outputFile);
        }
    }
}