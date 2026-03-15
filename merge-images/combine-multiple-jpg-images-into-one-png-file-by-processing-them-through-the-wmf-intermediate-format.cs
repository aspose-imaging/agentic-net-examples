using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Paths of source JPG images
        string[] jpgFiles = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // List to hold WMF images created from each JPG
        List<Image> wmfImages = new List<Image>();

        foreach (string jpgPath in jpgFiles)
        {
            // Load the JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Prepare WMF save options – use the size of the source image
                var wmfOptions = new WmfOptions
                {
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        PageSize = jpgImage.Size
                    }
                };

                // Save the JPG to a memory stream as WMF
                using (MemoryStream wmfStream = new MemoryStream())
                {
                    jpgImage.Save(wmfStream, wmfOptions);
                    wmfStream.Position = 0; // reset for reading

                    // Load the WMF image from the stream and keep it for later merging
                    Image wmfImage = Image.Load(wmfStream);
                    wmfImages.Add(wmfImage);
                }
            }
        }

        // Create a multipage image from the WMF images (first page will be used when saving to PNG)
        Image combinedImage = Image.Create(wmfImages.ToArray());

        // Save the combined result as a single PNG file
        combinedImage.Save(@"C:\Images\combined.png", new PngOptions());

        // Clean up resources
        combinedImage.Dispose();
        foreach (var img in wmfImages)
        {
            img.Dispose();
        }
    }
}