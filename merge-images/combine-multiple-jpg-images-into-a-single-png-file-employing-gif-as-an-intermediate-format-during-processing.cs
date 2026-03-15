using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class CombineJpgToPngViaGif
{
    static void Main()
    {
        // Paths of the source JPG images
        string[] jpgFiles = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Load the first JPG to obtain width and height for the GIF canvas
        using (RasterImage firstJpg = (RasterImage)Image.Load(jpgFiles[0]))
        {
            // Prepare GIF creation options (temporary file as the target)
            var gifCreateOptions = new GifOptions
            {
                Source = new FileCreateSource(@"C:\Temp\intermediate.gif", false)
            };

            // Create an empty GIF image with the same dimensions as the first JPG
            using (GifImage gifImage = (GifImage)Image.Create(gifCreateOptions, firstJpg.Width, firstJpg.Height))
            {
                // Add the first JPG as the first page of the GIF
                gifImage.AddPage(firstJpg);

                // Add remaining JPG images as additional pages
                for (int i = 1; i < jpgFiles.Length; i++)
                {
                    using (RasterImage jpg = (RasterImage)Image.Load(jpgFiles[i]))
                    {
                        gifImage.AddPage(jpg);
                    }
                }

                // Save the GIF as a PNG file.
                // Only the active (first) frame will be written to PNG, which is the combined result.
                var pngSaveOptions = new PngOptions();
                gifImage.Save(@"C:\Output\combined.png", pngSaveOptions);
            }
        }
    }
}