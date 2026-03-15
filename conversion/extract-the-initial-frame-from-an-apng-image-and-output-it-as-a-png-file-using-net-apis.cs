using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

string inputPath = "input.apng";
string outputPath = "first_frame.png";

using (ApngImage apng = (ApngImage)Image.Load(inputPath))
{
    // Get the first frame of the APNG
    ApngFrame firstFrame = (ApngFrame)apng.Pages[0];

    // Retrieve the full raster image for the frame
    using (RasterImage raster = firstFrame.GetFullFrame())
    {
        // Save the extracted frame as a PNG file
        raster.Save(outputPath, new PngOptions());
    }
}