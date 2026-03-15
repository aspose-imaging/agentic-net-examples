using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class TiffCombiner
{
    static void Main()
    {
        // Paths of source TIFF files to combine
        string[] sourceFiles = new string[]
        {
            @"C:\Images\page1.tif",
            @"C:\Images\page2.tif",
            @"C:\Images\page3.tif"
        };

        // Path of the resulting combined TIFF file
        string outputFile = @"C:\Images\combined.tif";

        // Load the first TIFF image – it will serve as the base container
        using (TiffImage combinedImage = (TiffImage)Image.Load(sourceFiles[0]))
        {
            // Iterate over the remaining TIFF files and merge their frames
            for (int i = 1; i < sourceFiles.Length; i++)
            {
                // Load the next TIFF image
                using (TiffImage nextImage = (TiffImage)Image.Load(sourceFiles[i]))
                {
                    // Add all frames from the next image into the combined image
                    combinedImage.Add(nextImage);
                }
            }

            // Save the combined multi‑page TIFF preserving original properties
            combinedImage.Save(outputFile);
        }
    }
}