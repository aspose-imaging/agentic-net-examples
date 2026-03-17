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

        // Load the first TIFF – it will serve as the base image.
        using (TiffImage combined = (TiffImage)Image.Load(sourceFiles[0]))
        {
            // Iterate over the remaining TIFF files and add their frames to the base image.
            for (int i = 1; i < sourceFiles.Length; i++)
            {
                // Load the current source TIFF.
                using (TiffImage source = (TiffImage)Image.Load(sourceFiles[i]))
                {
                    // Add all frames from the source image to the combined image.
                    // This method preserves metadata (Exif, XMP) and color profiles of each frame.
                    combined.Add(source);
                }
            }

            // Save the resulting multi‑frame TIFF while keeping original metadata intact.
            combined.Save(outputFile);
        }
    }
}