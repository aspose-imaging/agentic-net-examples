using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class WebpToGifConverter
{
    static void Main()
    {
        // Input WebP file (can be animated) and output GIF file paths
        string inputWebpPath = @"C:\Temp\input.webp";
        string outputGifPath = @"C:\Temp\output.gif";

        // Load the WebP image using the provided constructor (lifecycle rule)
        using (WebPImage webpImage = new WebPImage(inputWebpPath))
        {
            // Cast to multipage interface to access individual frames
            IMultipageImage multipageWebp = webpImage as IMultipageImage;
            if (multipageWebp == null || multipageWebp.PageCount == 0)
                throw new InvalidOperationException("The WebP image does not contain any frames.");

            // Use dimensions of the first frame for the GIF canvas
            int width = multipageWebp.Pages[0].Width;
            int height = multipageWebp.Pages[0].Height;

            // Prepare GIF creation options (no custom source needed for creation)
            GifOptions gifCreateOptions = new GifOptions
            {
                // Optional: enable palette correction to reduce colors for GIF format
                DoPaletteCorrection = true,
                // Optional: set infinite looping (0 means infinite in GIF spec)
                LoopsCount = 0
            };

            // Create an empty GIF image with the same size as the WebP frames (create rule)
            using (Image gifImageBase = Image.Create(gifCreateOptions, width, height))
            {
                // The created image is a GifImage; cast it for frame operations
                GifImage gifImage = gifImageBase as GifImage;
                if (gifImage == null)
                    throw new InvalidOperationException("Failed to create a GIF image.");

                // Add each WebP frame to the GIF as a new page
                for (int i = 0; i < multipageWebp.PageCount; i++)
                {
                    // Each page is a RasterImage; add it directly to the GIF
                    gifImage.AddPage(multipageWebp.Pages[i]);
                }

                // Save the assembled GIF using the same options (save rule)
                gifImage.Save(outputGifPath, gifCreateOptions);
            }
        }
    }
}