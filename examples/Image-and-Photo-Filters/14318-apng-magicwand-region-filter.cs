using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Paths to the source APNG and the result file
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access APNG‑specific members
            ApngImage apng = (ApngImage)image;

            // -----------------------------------------------------------------
            // 1. Create a magic‑wand mask based on a reference point (120,100)
            //    and a custom tolerance (Threshold = 150)
            // -----------------------------------------------------------------
            var wandSettings = new MagicWandSettings(120, 100) { Threshold = 150 };
            var mask = MagicWandTool.Select(apng, wandSettings);

            // Apply the mask – this makes the selected region transparent
            mask.Apply();

            // -----------------------------------------------------------------
            // 2. Apply a filter (Gaussian blur) to a region.
            //    Here we use the whole image bounds, but you could use any
            //    Rectangle that represents the area you want to process.
            // -----------------------------------------------------------------
            var rectangle = apng.Bounds; // Rectangle covering the entire image
            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
            apng.Filter(rectangle, blurOptions);

            // -----------------------------------------------------------------
            // 3. Save the modified APNG
            // -----------------------------------------------------------------
            apng.Save(outputPath);
        }
    }
}