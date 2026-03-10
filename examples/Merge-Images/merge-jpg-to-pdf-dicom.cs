using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // List of JPEG files to merge
        string[] jpgFiles = { "image1.jpg", "image2.jpg", "image3.jpg" };

        // Load all JPEG images as RasterImage objects
        List<RasterImage> rasterImages = new List<RasterImage>();
        foreach (string file in jpgFiles)
        {
            // Load each JPEG image
            rasterImages.Add((RasterImage)Image.Load(file));
        }

        // Assume all images have the same dimensions; use the first image for size
        int width = rasterImages[0].Width;
        int height = rasterImages[0].Height;

        // Create a multi‑page DICOM image with the determined size
        using (DicomImage dicom = (DicomImage)Image.Create(new DicomOptions(), width, height))
        {
            // Replace the default first page with the first JPEG image
            int[] firstPixels = rasterImages[0].LoadArgb32Pixels(rasterImages[0].Bounds);
            dicom.SaveArgb32Pixels(dicom.Bounds, firstPixels);

            // Add remaining JPEG images as additional pages
            for (int i = 1; i < rasterImages.Count; i++)
            {
                DicomPage page = dicom.AddPage();                     // Add a new blank page
                int[] pagePixels = rasterImages[i].LoadArgb32Pixels(rasterImages[i].Bounds);
                page.SaveArgb32Pixels(page.Bounds, pagePixels);       // Fill the page with JPEG pixels
            }

            // Save the merged multi‑page DICOM file (acts as a PDF‑like container)
            dicom.Save("merged.dcm");
        }

        // Clean up loaded JPEG images
        foreach (var img in rasterImages)
        {
            img.Dispose();
        }
    }
}