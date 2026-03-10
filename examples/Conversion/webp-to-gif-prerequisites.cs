using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class WebPToGifConversion
{
    static void Main()
    {
        // ---------- Prerequisites ----------
        // 1. Aspose.Imaging for .NET library must be referenced in the project.
        // 2. (Optional) Set a valid Aspose.Imaging license to avoid evaluation limitations.
        //    var license = new Aspose.Imaging.License();
        //    license.SetLicense("Aspose.Imaging.lic");
        // 3. The source WebP file must exist and be accessible.
        // 4. The destination folder must be writable.
        // 5. The Aspose.Imaging version used must support WebP (>= 22.10) and GIF formats.

        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output.gif";

        // Load the WebP image using the WebPImage constructor (lifecycle rule)
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Determine if the WebP image is animated (has more than one frame)
            bool isAnimated = webPImage.PageCount > 1;

            // Prepare GIF save options
            var gifOptions = new GifOptions();

            // If the source is animated, preserve animation settings where possible
            if (isAnimated)
            {
                // LoopCount is available on WebPImage for animated WebP.
                // Transfer it to the GIF options to keep the same looping behavior.
                gifOptions.LoopCount = webPImage.LoopCount;
            }

            // Save the image as GIF (save rule)
            webPImage.Save(outputPath, gifOptions);
        }
    }
}