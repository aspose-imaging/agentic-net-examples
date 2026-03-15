using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

// Path to the source APNG file
string inputPath = "input.apng";

// Path where the resulting PNG will be saved
string outputPath = "output.png";

// Load the APNG image (only the default/first frame will be used for PNG)
using (Image image = Image.Load(inputPath))
{
    // Save as PNG preserving the original quality
    image.Save(outputPath, new PngOptions());
}