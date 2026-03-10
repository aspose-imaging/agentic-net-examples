using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            var blendOptions = new ImageBlendingFilterOptions();
            apng.Filter(apng.Bounds, blendOptions);
            apng.Save(outputPath, new ApngOptions());
        }
    }
}