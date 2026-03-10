using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

class MergeJpgToPngViaGif
{
    static void Main()
    {
        // Define paths for source images and output files
        string dir = @"C:\temp\";
        string jpgPath = System.IO.Path.Combine(dir, "source.jpg");
        string pngPath = System.IO.Path.Combine(dir, "source.png");
        string gifPath = System.IO.Path.Combine(dir, "merged.gif");
        string resultPngPath = System.IO.Path.Combine(dir, "merged.png");

        // Load JPG and PNG images as RasterImage instances
        using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
        using (RasterImage pngImage = (RasterImage)Image.Load(pngPath))
        {
            // Create a GIF image with the same dimensions as the first image (JPG)
            var gifCreateOptions = new GifOptions
            {
                // Define where the GIF will be created
                Source = new FileCreateSource(gifPath, false)
            };

            using (GifImage gifImage = (GifImage)Image.Create(gifCreateOptions, jpgImage.Width, jpgImage.Height))
            {
                // Add the JPG as the first frame
                gifImage.AddPage(jpgImage);
                // Add the PNG as the second frame
                gifImage.AddPage(pngImage);

                // Save the intermediate GIF file
                gifImage.Save(gifPath);
            }

            // Load the created GIF and export its active frame (first frame) to PNG
            using (GifImage loadedGif = (GifImage)Image.Load(gifPath))
            {
                // Save the active frame as PNG using default PNG options
                loadedGif.Save(resultPngPath, new PngOptions());
            }
        }
    }
}