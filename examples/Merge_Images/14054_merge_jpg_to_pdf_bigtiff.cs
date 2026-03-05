using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff;

class MergeJpgToPdfUsingBigTiff
{
    static void Main()
    {
        // Paths to source JPEG files
        string[] jpgFiles = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Create an empty BigTiffImage (no initial frames)
        // Using the constructor that accepts an empty TiffFrame array
        using (var bigTiff = new BigTiffImage(new TiffFrame[0]))
        {
            // Load each JPEG, add it as a new page to the BigTiffImage
            foreach (string jpgPath in jpgFiles)
            {
                // Load JPEG as a RasterImage
                using (RasterImage raster = (RasterImage)Image.Load(jpgPath))
                {
                    // Add the raster image as a new page
                    bigTiff.AddPage(raster);
                }
            }

            // Prepare PDF save options (default compression)
            var pdfOptions = new PdfOptions();

            // Save the multi‑page BigTiffImage as a PDF file
            bigTiff.Save("merged_output.pdf", pdfOptions);
        }
    }
}