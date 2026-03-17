using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Paths of the source TIFF files to be merged
        string[] sourceFiles = new string[]
        {
            @"C:\Images\page1.tif",
            @"C:\Images\page2.tif",
            @"C:\Images\page3.tif"
        };

        // Path of the resulting multi‑page TIFF file
        string outputFile = @"C:\Images\merged.tif";

        // Load the first TIFF image – it will serve as the base image
        using (TiffImage mergedImage = (TiffImage)Image.Load(sourceFiles[0]))
        {
            // Iterate over the remaining TIFF files and add their frames to the base image
            for (int i = 1; i < sourceFiles.Length; i++)
            {
                // Load the current source TIFF
                using (TiffImage srcImage = (TiffImage)Image.Load(sourceFiles[i]))
                {
                    // Add all frames from srcImage into mergedImage, preserving original properties
                    mergedImage.Add(srcImage);
                }
            }

            // Save the combined multi‑page TIFF to disk
            mergedImage.Save(outputFile);
        }
    }
}