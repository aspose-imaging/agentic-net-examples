string dir = @"c:\temp\";

// Load a WebP image from a file.
using (Aspose.Imaging.FileFormats.Webp.WebPImage webPImage = new Aspose.Imaging.FileFormats.Webp.WebPImage(dir + "input.webp"))
{
    // Convert and save the image to GIF format.
    // GifOptions provides the necessary settings for GIF export.
    webPImage.Save(dir + "output.gif", new Aspose.Imaging.ImageOptions.GifOptions());
}