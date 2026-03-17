using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

 // Load a multi‑page image (e.g., TIFF, GIF, etc.). The pages are loaded in their original order.
using (Image multiPageImage = Image.Load("input.tif"))
{
    // Configure APNG options. DefaultFrameTime sets the duration of each frame (in milliseconds).
    var apngOptions = new ApngOptions
    {
        DefaultFrameTime = 100 // 100 ms per frame; adjust as needed.
    };

    // Save the image as an Animated PNG. The Save method preserves the page order automatically.
    multiPageImage.Save("output.png", apngOptions);
}