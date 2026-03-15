using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output_filtered.apng";

        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            for (int i = 0; i < apng.PageCount; i++)
            {
                ApngFrame frame = (ApngFrame)apng.Pages[i];
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                frame.Filter(frame.Bounds, blurOptions);
            }

            ApngOptions saveOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 200,
                NumPlays = 3,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            apng.Save(outputPath, saveOptions);
        }
    }
}