using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;

class MergeJpgUsingOdg
{
    static void Main()
    {
        // Paths to source JPG images
        string[] jpgFiles = { @"C:\Images\img1.jpg", @"C:\Images\img2.jpg", @"C:\Images\img3.jpg" };

        // Load each JPG as a RasterImage
        RasterImage[] rasterImages = new RasterImage[jpgFiles.Length];
        for (int i = 0; i < jpgFiles.Length; i++)
        {
            // Load JPG using the unified Image.Load method
            rasterImages[i] = (RasterImage)Image.Load(jpgFiles[i]);
        }

        // Create an empty ODG image (vector container) using a memory stream
        using (var odgStream = new MemoryStream())
        {
            // StreamContainer is required by the OdgImage constructor
            var streamContainer = new StreamContainer(odgStream);
            using (var odgImage = new OdgImage(streamContainer))
            {
                // Add each raster image as a page to the ODG document
                foreach (var raster in rasterImages)
                {
                    // AddPage is inherited from the base OdImage class
                    odgImage.AddPage(raster);
                }

                // Define JPEG saving options (rasterization will be performed automatically)
                var jpegOptions = new JpegOptions
                {
                    // Optional: set quality (0-100)
                    Quality = 90
                };

                // Save the merged result as a JPG file
                string outputPath = @"C:\Images\merged.jpg";
                odgImage.Save(outputPath, jpegOptions);
            }
        }

        // Dispose raster images
        foreach (var raster in rasterImages)
        {
            raster.Dispose();
        }

        Console.WriteLine("Images merged and saved to merged.jpg");
    }
}