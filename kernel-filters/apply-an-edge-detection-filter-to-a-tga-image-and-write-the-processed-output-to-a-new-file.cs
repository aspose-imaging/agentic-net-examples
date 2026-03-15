using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageFilters.FilterOptions;

string inputPath = "input.tga";
string outputPath = "output.tga";

using (TgaImage tgaImage = new TgaImage(inputPath))
{
    // Apply an edge detection filter to the whole image
    tgaImage.Filter(tgaImage.Bounds, new EdgeDetectionFilterOptions());

    // Save the processed image to a new file
    tgaImage.Save(outputPath);
}