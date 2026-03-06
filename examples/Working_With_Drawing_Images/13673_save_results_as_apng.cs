using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Load the source image (any supported format, e.g., WebP, TIFF, PNG, etc.)
        using (Image image = Image.Load("input.webp"))
        {
            // Save the loaded image as an Animated PNG (APNG) using default options.
            // The file will be written with a .png extension; the animation data is stored in the APNG format.
            image.Save("output.apng.png", new ApngOptions());
        }
    }
}