using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

string inputApngPath = "input.apng";
string outputPngPath = "output.png";

using (Image image = Image.Load(inputApngPath))
{
    // APNG files are loaded as ApngImage instances.
    ApngImage apngImage = image as ApngImage;

    if (apngImage != null)
    {
        // Save the default frame (first frame) as a raster PNG.
        PngOptions pngOptions = new PngOptions();
        apngImage.Save(outputPngPath, pngOptions);
    }
    else
    {
        // If the file is not an APNG, fall back to a generic PNG conversion.
        image.Save(outputPngPath, new PngOptions());
    }
}