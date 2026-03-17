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
        // Input TIFF files to be combined
        string[] inputFiles = new string[]
        {
            "input1.tif",
            "input2.tif",
            "input3.tif"
        };

        // Output multi‑page TIFF file
        string outputFile = "output.tif";

        // Load the first image to obtain width and height (assumes all images share the same dimensions)
        int width, height;
        using (RasterImage first = (RasterImage)Image.Load(inputFiles[0]))
        {
            width = first.Width;
            height = first.Height;
        }

        // Configure options for the resulting TIFF
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputFile, false);
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

        // Create the multi‑page TIFF image (a default frame is created automatically)
        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
        {
            // Add each input TIFF as a new frame
            foreach (string filePath in inputFiles)
            {
                using (RasterImage raster = (RasterImage)Image.Load(filePath))
                {
                    TiffFrame frame = new TiffFrame(raster);
                    tiffImage.AddFrame(frame);
                }
            }

            // Remove the initially created empty frame
            TiffFrame defaultFrame = tiffImage.ActiveFrame;
            tiffImage.ActiveFrame = tiffImage.Frames[1]; // set active to first real frame
            tiffImage.RemoveFrame(0); // remove the original empty frame
            defaultFrame.Dispose();

            // Save the multi‑page TIFF (the output file is already bound via FileCreateSource)
            tiffImage.Save();
        }
    }
}