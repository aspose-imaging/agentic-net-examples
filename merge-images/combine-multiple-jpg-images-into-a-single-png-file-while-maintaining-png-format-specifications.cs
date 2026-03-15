using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class CombineJpgToPng
{
    static void Main()
    {
        // Paths of source JPG images
        string[] jpgFiles = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Load all JPG images
        List<RasterImage> jpgImages = new List<RasterImage>();
        foreach (string file in jpgFiles)
        {
            // Load using the provided load rule
            Image img = Image.Load(file);
            // Cast to RasterImage for further processing
            jpgImages.Add((RasterImage)img);
        }

        // Determine combined image size (vertical stacking)
        int combinedWidth = 0;
        int combinedHeight = 0;
        foreach (RasterImage img in jpgImages)
        {
            if (img.Width > combinedWidth)
                combinedWidth = img.Width;          // use the widest image as width
            combinedHeight += img.Height;           // sum heights for vertical layout
        }

        // Create a blank PNG image with the calculated dimensions using the create rule
        PngOptions pngOptions = new PngOptions();   // default PNG options
        Image combinedImage = Image.Create(pngOptions, combinedWidth, combinedHeight);
        // Cast to PngImage to access PNG‑specific members if needed
        PngImage pngCanvas = (PngImage)combinedImage;

        // Paste each JPG onto the PNG canvas at the correct vertical offset
        int currentY = 0;
        foreach (RasterImage jpg in jpgImages)
        {
            // Blend the JPG onto the canvas at (0, currentY) with full opacity (255)
            // Blend method follows the provided rule: Blend(Point, RasterImage, byte)
            pngCanvas.Blend(new Aspose.Imaging.Point(0, currentY), jpg, 255);
            currentY += jpg.Height;
        }

        // Save the combined image as PNG using the provided save rule
        string outputPath = @"C:\Images\combined.png";
        pngCanvas.Save(outputPath, pngOptions);

        // Dispose all images to release resources
        foreach (RasterImage img in jpgImages)
            img.Dispose();
        pngCanvas.Dispose();
    }
}