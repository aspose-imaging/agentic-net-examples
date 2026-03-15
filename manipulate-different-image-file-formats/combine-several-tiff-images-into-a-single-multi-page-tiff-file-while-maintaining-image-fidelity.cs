using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input TIFF file paths
        string[] inputFiles = { @"C:\Images\page1.tif", @"C:\Images\page2.tif", @"C:\Images\page3.tif" };
        // Output multi‑page TIFF path
        string outputFile = @"C:\Images\combined.tif";

        TiffImage multiPageTiff = null;

        foreach (string filePath in inputFiles)
        {
            // Load each source TIFF image
            using (TiffImage src = (TiffImage)Image.Load(filePath))
            {
                if (multiPageTiff == null)
                {
                    // Initialize the result image with the frames of the first TIFF
                    multiPageTiff = new TiffImage(src.Frames);
                }
                else
                {
                    // Append all frames from the current image to the result
                    multiPageTiff.Add(src);
                }
            }
        }

        // Save the combined multi‑page TIFF
        multiPageTiff.Save(outputFile);
        multiPageTiff.Dispose();
    }
}