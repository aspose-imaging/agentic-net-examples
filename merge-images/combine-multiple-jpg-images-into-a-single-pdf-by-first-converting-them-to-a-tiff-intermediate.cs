using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputFiles = new string[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hard‑coded intermediate TIFF and final PDF paths
        string tiffPath = @"C:\Output\combined.tif";
        string pdfPath  = @"C:\Output\combined.pdf";

        // Ensure output directories exist (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(tiffPath));
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

        // Prepare a list to hold TIFF frames
        List<TiffFrame> frames = new List<TiffFrame>();

        // Load each JPG, convert to a TIFF frame and collect
        foreach (string inputPath in inputFiles)
        {
            using (Image img = Image.Load(inputPath))
            {
                // Cast to RasterImage because TiffFrame expects a RasterImage
                RasterImage raster = img as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine($"Unable to process non‑raster image: {inputPath}");
                    return;
                }

                // Create a TIFF frame from the raster image
                TiffFrame frame = new TiffFrame(raster);
                frames.Add(frame);
            }
        }

        // Create a multipage TIFF image from the collected frames
        using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
        {
            // Save the intermediate TIFF
            tiffImage.Save(tiffPath);
        }

        // Load the created TIFF and save it as PDF
        using (Image tiffImg = Image.Load(tiffPath))
        {
            // Save as PDF using default PDF options
            tiffImg.Save(pdfPath, new PdfOptions());
        }
    }
}